﻿// <auto-generated />
using System;
using GiftGivingGenerator.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GiftGivingGenerator.API.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20211215194637_AddedEndDateToEventAndPersonAndEventToAllocation")]
    partial class AddedEndDateToEventAndPersonAndEventToAllocation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EventPerson", b =>
                {
                    b.Property<Guid>("EventsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Ids")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EventsId", "Ids");

                    b.HasIndex("Ids");

                    b.ToTable("EventPerson");
                });

            modelBuilder.Entity("GiftGivingGenerator.API.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("GiftGivingGenerator.API.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("EventPerson", b =>
                {
                    b.HasOne("GiftGivingGenerator.API.Entities.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GiftGivingGenerator.API.Person", null)
                        .WithMany()
                        .HasForeignKey("Ids")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
