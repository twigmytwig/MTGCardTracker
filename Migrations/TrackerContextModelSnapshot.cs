﻿// <auto-generated />
using System;
using Card_Tracker_v3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Card_Tracker_v3.Migrations
{
    [DbContext(typeof(TrackerContext))]
    partial class TrackerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Card_Tracker_v3.Models.CardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CardType");
                });

            modelBuilder.Entity("Card_Tracker_v3.Models.CommanderDeck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AmountOfCards")
                        .HasColumnType("int");

                    b.Property<float?>("Cost")
                        .HasColumnType("real");

                    b.Property<string>("DeckName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MagicGameFormatsId")
                        .HasColumnType("int");

                    b.Property<bool>("PlayReadyStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MagicGameFormatsId");

                    b.ToTable("CommanderDeck");
                });

            modelBuilder.Entity("Card_Tracker_v3.Models.DeckLookUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardAmount")
                        .HasColumnType("int");

                    b.Property<string>("CardName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CommanderDeckId")
                        .HasColumnType("int");

                    b.Property<bool>("LegalityStatus")
                        .HasColumnType("bit");

                    b.Property<bool>("isCommander")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CardTypeId");

                    b.HasIndex("CommanderDeckId");

                    b.ToTable("DeckLookUp");
                });

            modelBuilder.Entity("Card_Tracker_v3.Models.MagicGameFormats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FormatName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MagicGameFormats");
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

            modelBuilder.Entity("Card_Tracker_v3.Models.CommanderDeck", b =>
                {
                    b.HasOne("Card_Tracker_v3.Models.MagicGameFormats", "MagicGameFormats")
                        .WithMany()
                        .HasForeignKey("MagicGameFormatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MagicGameFormats");
                });

            modelBuilder.Entity("Card_Tracker_v3.Models.DeckLookUp", b =>
                {
                    b.HasOne("Card_Tracker_v3.Models.CardType", "CardType")
                        .WithMany()
                        .HasForeignKey("CardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Card_Tracker_v3.Models.CommanderDeck", "CommanderDeck")
                        .WithMany()
                        .HasForeignKey("CommanderDeckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CardType");

                    b.Navigation("CommanderDeck");
                });
#pragma warning restore 612, 618
        }
    }
}
