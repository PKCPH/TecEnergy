﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TecEnergy.Database;

#nullable disable

namespace TecEnergy.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231103072420_nullableEnergymeter")]
    partial class nullableEnergymeter
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TecEnergy.Database.DataModels.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BuildingName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("TecEnergy.Database.DataModels.EnergyData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EnergyMeterID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("EnergyMeterID");

                    b.ToTable("EnergyData");
                });

            modelBuilder.Entity("TecEnergy.Database.DataModels.EnergyMeter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConnectionState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InstallmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MeasurementPointComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasurementPointName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasurementType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReadingFrequency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EnergyMeters");
                });

            modelBuilder.Entity("TecEnergy.Database.DataModels.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuildingID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoomComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("TecEnergy.Database.DataModels.EnergyData", b =>
                {
                    b.HasOne("TecEnergy.Database.DataModels.EnergyMeter", "EnergyMeter")
                        .WithMany()
                        .HasForeignKey("EnergyMeterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EnergyMeter");
                });

            modelBuilder.Entity("TecEnergy.Database.DataModels.Room", b =>
                {
                    b.HasOne("TecEnergy.Database.DataModels.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });
#pragma warning restore 612, 618
        }
    }
}
