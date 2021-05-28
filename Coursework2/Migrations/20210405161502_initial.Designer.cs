﻿// <auto-generated />
using System;
using Coursework2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Coursework2.Migrations
{
    [DbContext(typeof(AppDBContent))]
    [Migration("20210405161502_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Coursework2.Data.Models.Client_Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id_Session")
                        .HasColumnType("int");

                    b.Property<int>("Id_User")
                        .HasColumnType("int");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_Session");

                    b.HasIndex("UsersId");

                    b.ToTable("Client_Session");
                });

            modelBuilder.Entity("Coursework2.Data.Models.Game_session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdLeading")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdLeading");

                    b.ToTable("Game_session");
                });

            modelBuilder.Entity("Coursework2.Data.Models.Leading", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Leading");
                });

            modelBuilder.Entity("Coursework2.Data.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Coursework2.Data.Models.Client_Session", b =>
                {
                    b.HasOne("Coursework2.Data.Models.Game_session", "Game_session")
                        .WithMany()
                        .HasForeignKey("Id_Session")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Coursework2.Data.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");

                    b.Navigation("Game_session");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Coursework2.Data.Models.Game_session", b =>
                {
                    b.HasOne("Coursework2.Data.Models.Leading", "Leading")
                        .WithMany()
                        .HasForeignKey("IdLeading")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leading");
                });
#pragma warning restore 612, 618
        }
    }
}