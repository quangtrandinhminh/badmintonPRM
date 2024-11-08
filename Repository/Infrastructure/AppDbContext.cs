using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Infrastructure;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Yard> Yards { get; set; }
    public virtual DbSet<YardImage> YardImages { get; set; }
    public virtual DbSet<Slot> Slots { get; set; }
    public virtual DbSet<BookingOrders> BookingOrders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                Username = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("123"),
                Role = 1
            },
            new User
            {
                UserId = 2,
                Username = "staff",
                Password = BCrypt.Net.BCrypt.HashPassword("123"),
                Role = 2
            },
            new User
            {
                UserId = 3,
                Username = "owner",
                Password = BCrypt.Net.BCrypt.HashPassword("123"),
                Role = 3
            },
            new User
            {
                UserId = 4,
                Username = "cus",
                Password = BCrypt.Net.BCrypt.HashPassword("123"),
                Role = 4
            }
        );

        // add yard data
        modelBuilder.Entity<Yard>().HasData(
                       new Yard
                       {
                YardId = 1,
                Name = "Yard 1",
                Address = "123 Phan Văn Trị, Gò Vấp, Hồ Chí Minh",
                ProvinceId = 1,
                OpenTime = new TimeOnly(7, 0),
                CloseTime = new TimeOnly(22, 0),
                Description = "Sân bóng đẹp, sạch sẽ, thoáng đãng",
                OwnerId = 3,
                IsActive = true
            },
                                  new Yard
                                  {
                YardId = 2,
                Name = "Yard 2",
                Address = "124 Phan Văn Trị, Gò Vấp, Hồ Chí Minh",
                ProvinceId = 1,
                OpenTime = new TimeOnly(7, 0),
                CloseTime = new TimeOnly(22, 0),
                Description = "Sân bóng đẹp, sạch sẽ, thoáng đãng",
                OwnerId = 3,
                IsActive = true
            },
                                  new Yard
                                  {
                YardId = 3,
                Name = "Yard 3",
                Address = "123 Phan Văn Trị, Gò Vấp, Hồ Chí Minh",
                ProvinceId = 1,
                OpenTime = new TimeOnly(7, 0),
                CloseTime = new TimeOnly(22, 0),
                Description = "Sân bóng đẹp, sạch sẽ, thoáng đãng",
                OwnerId = 3,
                IsActive = true
            }
        );
    }
}
