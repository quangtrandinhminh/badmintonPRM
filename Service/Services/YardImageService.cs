using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Repository.Base;
using Repository.Infrastructure;
using Repository.Models;
using Service.Constants;
using Service.Exceptions;
using Service.Mapper;
using Service.Models;

namespace Service.Services;

public class YardImageService(IServiceProvider serviceProvider)
{
    private readonly IBaseRepository<YardImage> _primaryRepository =
        serviceProvider.GetRequiredService<IBaseRepository<YardImage>>();

    private readonly MapperlyMapper _mapper = serviceProvider.GetRequiredService<MapperlyMapper>();
    private readonly IUnitOfWork _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();

    public IQueryable<YardImage?> GetAll(int? yardId)
    {
        return _primaryRepository.GetAllWithCondition(x => yardId == null || x.YardId == yardId);
    }

    public async Task<YardImage?> GetById(int id)
    {
        var entity = await _primaryRepository.GetSingleAsync(x => x.YardImageId == id, x => x.Yard);
        if (entity == null)
        {
            throw new AppException(ResponseCodeConstants.NOT_FOUND, "Not found !",
                StatusCodes.Status404NotFound);
        }

        return entity;
    }

    public void Add(YardImageRequest request)
    {
        _primaryRepository.Add(_mapper.Map(request));
        _unitOfWork.SaveChange();
    }

    public async Task Update(int id, YardImageRequest request)
    {
        var entity = await GetById(id);
        _mapper.Map(request, entity);
        _primaryRepository.Update(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);
        _primaryRepository.Delete(entity);
        await _unitOfWork.SaveChangeAsync();
    }
}