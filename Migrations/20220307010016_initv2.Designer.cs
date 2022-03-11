﻿// <auto-generated />
using Card_Tracker_v3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Card_Tracker_v3.Migrations
{
    [DbContext(typeof(TrackerContext))]
    [Migration("20220307010016_initv2")]
    partial class initv2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Card_Tracker_v3.Models.CardRepositories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RepositoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CardRepositories");
                });

            modelBuilder.Entity("Card_Tracker_v3.Models.CardRepositoryLookUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("CardApiID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardRepositoriesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardRepositoriesId");

                    b.ToTable("CardRepositoryLookUp");
                });

            modelBuilder.Entity("Card_Tracker_v3.Models.CardRepositoryLookUp", b =>
                {
                    b.HasOne("Card_Tracker_v3.Models.CardRepositories", "CardRepositories")
                        .WithMany()
                        .HasForeignKey("CardRepositoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardRepositories");
                });
#pragma warning restore 612, 618
        }
    }
}
