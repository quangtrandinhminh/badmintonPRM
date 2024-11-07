namespace Repository.Models;

public class Entity1
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string GroupName { get; set; } = null!;

    public virtual ICollection<Entity> Entities { get; set; } = new List<Entity>();
}