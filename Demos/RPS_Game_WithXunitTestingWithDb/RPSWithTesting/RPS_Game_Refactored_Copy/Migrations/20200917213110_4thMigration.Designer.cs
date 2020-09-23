﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPS_Game_Refactored.Models;

namespace RPS_Game_Refactored.Migrations
{
    [DbContext(typeof(DbContextClass))]
    [Migration("20200917213110_4thMigration")]
    partial class _4thMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RPS_Game_Refactored.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComputerPlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("Player1PlayerId")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("ComputerPlayerId");

                    b.HasIndex("Player1PlayerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("RPS_Game_Refactored.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("RPS_Game_Refactored.Round", b =>
                {
                    b.Property<int>("RoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComputerChoice")
                        .HasColumnType("int");

                    b.Property<int?>("ComputerPlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("Outcome")
                        .HasColumnType("int");

                    b.Property<int>("p1Choice")
                        .HasColumnType("int");

                    b.Property<int?>("player1PlayerId")
                        .HasColumnType("int");

                    b.HasKey("RoundId");

                    b.HasIndex("ComputerPlayerId");

                    b.HasIndex("GameId");

                    b.HasIndex("player1PlayerId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("RPS_Game_Refactored.Game", b =>
                {
                    b.HasOne("RPS_Game_Refactored.Player", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerPlayerId");

                    b.HasOne("RPS_Game_Refactored.Player", "Player1")
                        .WithMany()
                        .HasForeignKey("Player1PlayerId");
                });

            modelBuilder.Entity("RPS_Game_Refactored.Round", b =>
                {
                    b.HasOne("RPS_Game_Refactored.Player", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerPlayerId");

                    b.HasOne("RPS_Game_Refactored.Game", "game")
                        .WithMany()
                        .HasForeignKey("GameId");

                    b.HasOne("RPS_Game_Refactored.Player", "player1")
                        .WithMany()
                        .HasForeignKey("player1PlayerId");
                });
#pragma warning restore 612, 618
        }
    }
}
