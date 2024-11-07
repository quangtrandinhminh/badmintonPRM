using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Entity
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public int? Entity1Id { get; set; }

    public virtual Entity1? Entity1 { get; set; }
}
