namespace Service.Models;

public class SlotRequest
{
    public int YardId { get; set; }
    public double Price { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}