using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models;

public class YardImage
{
    [Key]
    public int YardImageId { get; set; }
    public string Image { get; set; }
    public int YardId { get; set; }

    [ForeignKey("YardId")]
    public Yard Yard { get; set; }
}