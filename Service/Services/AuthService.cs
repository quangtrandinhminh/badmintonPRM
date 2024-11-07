using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repository.Base;
using Repository.Infrastructure;
using Repository.Models;
using Serilog;
using Service.Constants;
using Service.Exceptions;
using Service.Mapper;
using Service.Models.User;
using Service.Utils;

namespace Service.Services;

public class AuthService(IServiceProvider serviceProvider)
{
    private IBaseRepository<User> _userRepository = serviceProvider.GetRequiredService<IBaseRepository<User>>();
    private ILogger _logger = serviceProvider.GetRequiredService<ILogger>();
    private MapperlyMapper _mapper = serviceProvider.GetRequiredService<MapperlyMapper>();
    private IUnitOfWork _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();

    public async Task<AuthResponse> Authenticate(SignInRequest request)
    {
        var user = await _userRepository.GetSingleAsync(x => x.Username == request.Username);
        if (user == null)
        {
            throw new AppException(ResponseCodeConstants.NOT_FOUND, UserMessageConstants.USER_NOT_FOUND,
                StatusCodes.Status404NotFound);
        }

        var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
        if (!isPasswordValid)
        {
            throw new AppException(ResponseCodeConstants.UNAUTHORIZED, UserMessageConstants.USER_UNAUTHORIZED,
                               StatusCodes.Status401Unauthorized);
        }

        var response = _mapper.Map(user);
        response.Token = await GenerateJwtToken(user);
        await _unitOfWork.SaveChangeAsync();

        return response;
    }

    public async Task<AuthResponse> Register(SignUpRequest request)
    {
        var user = await _userRepository.GetSingleAsync(x => x.Username == request.Username);
        if (user != null)
        {
            throw new AppException(ResponseCodeConstants.CONFLICT, UserMessageConstants.USER_CONFLICT,
                               StatusCodes.Status409Conflict);
        }

        var newUser = _mapper.Map(request);
        newUser.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
        _userRepository.Add(newUser);
        await _unitOfWork.SaveChangeAsync();

        return _mapper.Map(newUser);
    }

    private async Task<string> GenerateJwtToken(User loggedUser)
    {
        var claims = new List<Claim>();
        claims.AddRange(new[]
        {
            new Claim(ClaimTypes.Sid, loggedUser.UserId.ToString()),
            new Claim("UserName", loggedUser.Username ?? string.Empty),
            new Claim(ClaimTypes.Role, loggedUser.Role.ToString()),
            new Claim(ClaimTypes.Expired, DateTime.UtcNow.AddHours(24).ToString())
        });

        return JwtUtils.GenerateToken(claims.Distinct());
    }
} 