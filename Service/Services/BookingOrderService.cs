using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.DependencyInjection;
using Repository.Base;
using Repository.Infrastructure;
using Repository.Models;
using Service.Constants;
using Service.Exceptions;
using Service.Mapper;
using Service.Models;

namespace Service.Services;

public class BookingOrderService(IServiceProvider serviceProvider)
{
    private readonly IBaseRepository<BookingOrders> _bookingOrderRepository =
        serviceProvider.GetRequiredService<IBaseRepository<BookingOrders>>();

    private readonly MapperlyMapper _mapper = serviceProvider.GetRequiredService<MapperlyMapper>();
    private readonly IUnitOfWork _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    private readonly IBaseRepository<Slot> _slotRepository = serviceProvider.GetRequiredService<IBaseRepository<Slot>>();
    private readonly IBaseRepository<Yard> _yardRepository = serviceProvider.GetRequiredService<IBaseRepository<Yard>>();

    public IQueryable<BookingOrders?> GetAll(int customerId)
    {
        return _bookingOrderRepository.GetAllWithCondition(
            x => x.UserId == customerId && x.IsActive,
            x => x.Slots);
    }

    public async Task<BookingOrders?> GetById(int id)
    {
        var entity = await _bookingOrderRepository.GetSingleAsync(
            x => x.BookingOrderId == id, x => x.Slots);
        if (entity == null)
        {
            throw new AppException(ResponseCodeConstants.NOT_FOUND, "Not found !",
                StatusCodes.Status404NotFound);
        }

        return entity;
    }

    public BookingOrders Add(BookingOrderRequest request)
    {
        var slots = _slotRepository.GetAllWithCondition(x => request.SlotIds.Contains(x.SlotId)).ToList();
        var entity = _mapper.Map(request);
        entity.Slots = slots;
        _slotRepository.TryAttachRange(entity.Slots);
        entity.Total = slots.Sum(x => x.Price);
        entity = _bookingOrderRepository.Add(entity);
        _unitOfWork.SaveChange();

        return entity;
    }

    public async Task Update(int id, BookingOrderRequest request)
    {
        var entity = await GetById(id);
        _mapper.Map(request, entity);
        _bookingOrderRepository.Update(entity);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);
        entity.IsActive = false;
        _bookingOrderRepository.Update(entity);
        await _unitOfWork.SaveChangeAsync();
    }
}