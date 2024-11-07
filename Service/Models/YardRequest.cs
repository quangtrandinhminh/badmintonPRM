namespace Service.Models;

public class YardRequest
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int ProvinceId { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public int OwnerId { get; set; }
}