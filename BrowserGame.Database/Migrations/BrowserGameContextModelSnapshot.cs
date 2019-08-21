﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BrowserGame.Database.Migrations
{
    [DbContext(typeof(BrowserGameContext))]
    partial class BrowserGameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("BrowserGame.Database.Models.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Size");

                    b.HasKey("Id");

                    b.ToTable("Planets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Size = 13
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
