﻿// <auto-generated />
using System;
using MInitweetApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MinitweetApi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220220165042_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MInitweetApi.Models.Follower", b =>
                {
                    b.Property<Guid>("who_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("who_useruser_Id")
                        .HasColumnType("integer");

                    b.Property<int>("whom_useruser_Id")
                        .HasColumnType("integer");

                    b.HasKey("who_id");

                    b.HasIndex("who_useruser_Id");

                    b.HasIndex("whom_useruser_Id");

                    b.ToTable("Follower");
                });

            modelBuilder.Entity("MInitweetApi.Models.Message", b =>
                {
                    b.Property<int>("message_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("message_Id"));

                    b.Property<int>("author_id")
                        .HasColumnType("integer");

                    b.Property<bool>("flagged")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("pub_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("user_Id")
                        .HasColumnType("integer");

                    b.HasKey("message_Id");

                    b.HasIndex("user_Id");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("MInitweetApi.Models.User", b =>
                {
                    b.Property<int>("user_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("user_Id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("pw_hash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("user_Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MInitweetApi.Models.Follower", b =>
                {
                    b.HasOne("MInitweetApi.Models.User", "who_user")
                        .WithMany()
                        .HasForeignKey("who_useruser_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MInitweetApi.Models.User", "whom_user")
                        .WithMany()
                        .HasForeignKey("whom_useruser_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("who_user");

                    b.Navigation("whom_user");
                });

            modelBuilder.Entity("MInitweetApi.Models.Message", b =>
                {
                    b.HasOne("MInitweetApi.Models.User", "user")
                        .WithMany("messages")
                        .HasForeignKey("user_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("MInitweetApi.Models.User", b =>
                {
                    b.Navigation("messages");
                });
#pragma warning restore 612, 618
        }
    }
}