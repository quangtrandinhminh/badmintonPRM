﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Repository.Infrastructure;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241108041909_Add_Slot")]
    partial class Add_Slot
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookingOrdersSlot", b =>
                {
                    b.Property<int>("BookingOrdersBookingOrderId")
                        .HasColumnType("integer");

                    b.Property<int>("SlotsSlotId")
                        .HasColumnType("integer");

                    b.HasKey("BookingOrdersBookingOrderId", "SlotsSlotId");

                    b.HasIndex("SlotsSlotId");

                    b.ToTable("BookingOrdersSlot");
                });

            modelBuilder.Entity("Repository.Models.BookingOrders", b =>
                {
                    b.Property<int>("BookingOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookingOrderId"));

                    b.Property<DateOnly>("BookingDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("BookingOrderId");

                    b.HasIndex("UserId");

                    b.ToTable("BookingOrders");
                });

            modelBuilder.Entity("Repository.Models.Slot", b =>
                {
                    b.Property<int>("SlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SlotId"));

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time without time zone");

                    b.Property<int>("YardId")
                        .HasColumnType("integer");

                    b.HasKey("SlotId");

                    b.HasIndex("YardId");

                    b.ToTable("Slots");

                    b.HasData(
                        new
                        {
                            SlotId = 1,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 1
                        },
                        new
                        {
                            SlotId = 2,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 1
                        },
                        new
                        {
                            SlotId = 3,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 1
                        },
                        new
                        {
                            SlotId = 4,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 1
                        },
                        new
                        {
                            SlotId = 5,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 1
                        },
                        new
                        {
                            SlotId = 6,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 2
                        },
                        new
                        {
                            SlotId = 7,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 2
                        },
                        new
                        {
                            SlotId = 8,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 2
                        },
                        new
                        {
                            SlotId = 9,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 2
                        },
                        new
                        {
                            SlotId = 10,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 2
                        },
                        new
                        {
                            SlotId = 11,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 3
                        },
                        new
                        {
                            SlotId = 12,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 3
                        },
                        new
                        {
                            SlotId = 13,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 3
                        },
                        new
                        {
                            SlotId = 14,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 3
                        },
                        new
                        {
                            SlotId = 15,
                            EndTime = new TimeOnly(0, 0, 0),
                            IsActive = true,
                            Price = 100000.0,
                            StartTime = new TimeOnly(0, 0, 0),
                            YardId = 3
                        });
                });

            modelBuilder.Entity("Repository.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "$2a$11$Y7MreXbBTN1M62isBRpb7euXD7Zo9UswuQQl0fSqKXHGgniZf3lOq",
                            Role = 1,
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            Password = "$2a$11$HQaANF/ibmy.avYSe8R9k.JxHhUWF90hJB6efNZPTthdIkygvMOby",
                            Role = 2,
                            Username = "staff"
                        },
                        new
                        {
                            UserId = 3,
                            Password = "$2a$11$l7MsLy8rb7IXyqR8.rT78.a3qenNV0iGnpUD2TUb96Is4VDmbA7qm",
                            Role = 3,
                            Username = "owner"
                        },
                        new
                        {
                            UserId = 4,
                            Password = "$2a$11$/WKCi/k7XHwP8xiL7qSoHuPjgqSvoLzoWxwQkmSCqFWhslEFX5S6a",
                            Role = 4,
                            Username = "cus"
                        });
                });

            modelBuilder.Entity("Repository.Models.Yard", b =>
                {
                    b.Property<int>("YardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("YardId"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<TimeOnly?>("CloseTime")
                        .HasColumnType("time without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<TimeOnly?>("OpenTime")
                        .HasColumnType("time without time zone");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProvinceId")
                        .HasColumnType("integer");

                    b.HasKey("YardId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Yards");

                    b.HasData(
                        new
                        {
                            YardId = 1,
                            Address = "123 Phan Văn Trị, Gò Vấp, Hồ Chí Minh",
                            CloseTime = new TimeOnly(22, 0, 0),
                            Description = "Sân bóng đẹp, sạch sẽ, thoáng đãng",
                            IsActive = true,
                            Name = "Yard 1",
                            OpenTime = new TimeOnly(7, 0, 0),
                            OwnerId = 3,
                            ProvinceId = 1
                        },
                        new
                        {
                            YardId = 2,
                            Address = "124 Phan Văn Trị, Gò Vấp, Hồ Chí Minh",
                            CloseTime = new TimeOnly(22, 0, 0),
                            Description = "Sân bóng đẹp, sạch sẽ, thoáng đãng",
                            IsActive = true,
                            Name = "Yard 2",
                            OpenTime = new TimeOnly(7, 0, 0),
                            OwnerId = 3,
                            ProvinceId = 1
                        },
                        new
                        {
                            YardId = 3,
                            Address = "123 Phan Văn Trị, Gò Vấp, Hồ Chí Minh",
                            CloseTime = new TimeOnly(22, 0, 0),
                            Description = "Sân bóng đẹp, sạch sẽ, thoáng đãng",
                            IsActive = true,
                            Name = "Yard 3",
                            OpenTime = new TimeOnly(7, 0, 0),
                            OwnerId = 3,
                            ProvinceId = 1
                        });
                });

            modelBuilder.Entity("Repository.Models.YardImage", b =>
                {
                    b.Property<int>("YardImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("YardImageId"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("YardId")
                        .HasColumnType("integer");

                    b.HasKey("YardImageId");

                    b.HasIndex("YardId");

                    b.ToTable("YardImages");
                });

            modelBuilder.Entity("BookingOrdersSlot", b =>
                {
                    b.HasOne("Repository.Models.BookingOrders", null)
                        .WithMany()
                        .HasForeignKey("BookingOrdersBookingOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Repository.Models.Slot", null)
                        .WithMany()
                        .HasForeignKey("SlotsSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Repository.Models.BookingOrders", b =>
                {
                    b.HasOne("Repository.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Repository.Models.Slot", b =>
                {
                    b.HasOne("Repository.Models.Yard", "Yard")
                        .WithMany("Slots")
                        .HasForeignKey("YardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Yard");
                });

            modelBuilder.Entity("Repository.Models.Yard", b =>
                {
                    b.HasOne("Repository.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Repository.Models.YardImage", b =>
                {
                    b.HasOne("Repository.Models.Yard", "Yard")
                        .WithMany("YardImages")
                        .HasForeignKey("YardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Yard");
                });

            modelBuilder.Entity("Repository.Models.Yard", b =>
                {
                    b.Navigation("Slots");

                    b.Navigation("YardImages");
                });
#pragma warning restore 612, 618
        }
    }
}
