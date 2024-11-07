using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models;

public class BookingOrders
{
    [Key]
    public int BookingOrderId { get; set; }
    public int UserId { get; set; }
    public DateOnly BookingDate { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual ICollection<Slot> Slots { get; set; } = new List<Slot>();

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = null!;
}