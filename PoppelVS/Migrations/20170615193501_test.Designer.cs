using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PoppelProject.Models;

namespace PoppelProject.Migrations
{
    [DbContext(typeof(appDbContext))]
    [Migration("20170615193501_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PoppelProject.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("SiteId");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("House");
                });

            modelBuilder.Entity("PoppelProject.Models.Line", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmountOfFood");

                    b.Property<DateTime>("Date");

                    b.Property<int>("HouseId");

                    b.Property<int>("LitersOfWater");

                    b.Property<int>("NumberOfEggs");

                    b.Property<int?>("RoundId");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Line");
                });

            modelBuilder.Entity("PoppelProject.Models.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("HouseId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("PoppelProject.Models.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("PoppelProject.Models.House", b =>
                {
                    b.HasOne("PoppelProject.Models.Site", "Site")
                        .WithMany("Houses")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PoppelProject.Models.Line", b =>
                {
                    b.HasOne("PoppelProject.Models.Round")
                        .WithMany("Lines")
                        .HasForeignKey("RoundId");
                });

            modelBuilder.Entity("PoppelProject.Models.Round", b =>
                {
                    b.HasOne("PoppelProject.Models.House")
                        .WithMany("Rounds")
                        .HasForeignKey("HouseId");
                });
        }
    }
}
