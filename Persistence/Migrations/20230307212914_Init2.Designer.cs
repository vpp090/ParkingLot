﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230307212914_Init2")]
    partial class Init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DailyChargePerHour")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OvernightChargePerHour")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpacesUsed")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiscountPercentage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiscountType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Domain.ParkingLot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ParkingLot");
                });

            modelBuilder.Entity("Domain.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DiscountTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParkingLotId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("VehicleEntryTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("VehicleInParking")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DiscountTypeId");

                    b.HasIndex("ParkingLotId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Domain.Vehicle", b =>
                {
                    b.HasOne("Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Domain.Discount", "DiscountType")
                        .WithMany()
                        .HasForeignKey("DiscountTypeId");

                    b.HasOne("Domain.ParkingLot", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("ParkingLotId");

                    b.Navigation("Category");

                    b.Navigation("DiscountType");
                });

            modelBuilder.Entity("Domain.ParkingLot", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
