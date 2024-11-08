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

public class YardService(IServiceProvider serviceProvider)
{
    private readonly IBaseRepository<Yard> _primaryRepository =
        serviceProvider.GetRequiredService<IBaseRepository<Yard>>();

    private readonly MapperlyMapper _mapper = serviceProvider.GetRequiredService<MapperlyMapper>();
    private readonly IUnitOfWork _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();

    public IList<Yard?> GetAll(int pageNumber)
    {
        var pageSize = 5;
        return _primaryRepository.GetAllWithCondition(x => x.IsActive, includeProperties: x => x.YardImages
        ).Skip((pageNumber - 1) * 10).Take(pageSize).ToList();
    }

    public async Task<Yard?> GetById(int id)
    {
        var entity = await _primaryRepository.GetSingleAsync(
            x => x.YardId == id && x.IsActive, 
            x => x.Slots, x => x.YardImages);
        if (entity == null)
        {
            throw new AppException(ResponseCodeConstants.NOT_FOUND, "Not found !",
                StatusCodes.Status404NotFound);
        }

        return entity;
    }

    public void Add(YardRequest request)
    {
        _primaryRepository.Add(_mapper.Map(request));
        _unitOfWork.SaveChange();
    }

    public async Task Update(int id, YardRequest request)
    {
        var entity = await GetById(id);
        _mapper.Map(request, entity);
        _primaryRepository.Update(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);
        entity.IsActive = false;
        _primaryRepository.Update(entity);
        await _unitOfWork.SaveChangeAsync();
    }
}