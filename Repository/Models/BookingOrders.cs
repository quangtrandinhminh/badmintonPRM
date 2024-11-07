using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models;

public class BookingOrders
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateOnly BookingDate { get; set; }
    public bool IsActive { get; set; }
    public virtual ICollection<Slot> Slots { get; set; } = null!;

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
}