using Repository.Models;

namespace Service.Models;

public class BookingOrderRequest
{
    public int UserId { get; set; }
    public DateOnly BookingDate { get; set; }
    public IList<int> SlotIds { get; set; } = new List<int>();
}