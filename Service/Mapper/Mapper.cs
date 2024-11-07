using Microsoft.AspNetCore.Identity.Data;
using Repository.Extensions;
using Repository.Models;
using Riok.Mapperly.Abstractions;
using Service.Models;
using Service.Models.PaginatedList;
using Service.Models.User;

namespace Service.Mapper;

[Mapper]
public partial class MapperlyMapper
{
    // User
    public partial AuthResponse Map(User entity);
    public partial User Map(SignUpRequest request);
    public partial Entity Map(PrimaryRequest request);
    public partial void Map(PrimaryRequest request, Entity entity);

    public partial Yard Map(YardRequest request);
    public partial void Map(YardRequest request, Yard entity);

    public partial Slot Map(SlotRequest request);
    public partial void Map(SlotRequest request, Slot entity);
}