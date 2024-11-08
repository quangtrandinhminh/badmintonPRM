﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Repository.Base;
using Repository.Infrastructure;
using Repository.Models;
using Service.Constants;
using Service.Exceptions;
using Service.Mapper;
using Service.Models;

namespace Service.Services;

public class PrimaryService(IServiceProvider serviceProvider)
{
    private readonly IBaseRepository<Entity> _primaryRepository =
        serviceProvider.GetRequiredService<IBaseRepository<Entity>>();

    private readonly MapperlyMapper _mapper = serviceProvider.GetRequiredService<MapperlyMapper>();
    private readonly IUnitOfWork _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();

    public IQueryable<Entity?> GetAll()
    {
        return _primaryRepository.GetAll();
    }

    public async Task<Entity?> GetById(int id)
    {
        var entity = await _primaryRepository.GetSingleAsync(x => x.Id == id, x => x.Entity1);
        if (entity == null)
        {
            throw new AppException(ResponseCodeConstants.NOT_FOUND, "Not found !",
                StatusCodes.Status404NotFound);
        }

        return entity;
    }

    public void Add(PrimaryRequest request)
    {
        _primaryRepository.Add(_mapper.Map(request));
        _unitOfWork.SaveChange();
    }

    public async Task Update(int id, PrimaryRequest request)
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