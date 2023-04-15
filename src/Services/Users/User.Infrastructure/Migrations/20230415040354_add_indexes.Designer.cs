﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Users.Infrastructure;

#nullable disable

namespace Users.Infrastructure.Migrations
{
    [DbContext(typeof(UsersContext))]
    [Migration("20230415040354_add_indexes")]
    partial class add_indexes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Users.Domain.Aggregates.Users.TwitchUser", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_scopes")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Scopes");

                    b.HasKey("Id");

                    b.ToTable("twitch_users", "users");
                });

            modelBuilder.Entity("Users.Domain.Aggregates.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TwitchUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TwitchUserId");

                    b.ToTable("users", "users");
                });

            modelBuilder.Entity("Users.Domain.Aggregates.Users.User", b =>
                {
                    b.HasOne("Users.Domain.Aggregates.Users.TwitchUser", "TwitchUser")
                        .WithMany()
                        .HasForeignKey("TwitchUserId");

                    b.OwnsOne("Users.Domain.Aggregates.Users.Credentials", "Credentials", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("DisplayName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Login")
                                .IsRequired()
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UserId");

                            b1.HasIndex("Email")
                                .IsUnique()
                                .HasDatabaseName("Unique_Email");

                            b1.HasIndex("Login")
                                .IsUnique()
                                .HasDatabaseName("Unique_Login");

                            b1.ToTable("users", "users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Credentials")
                        .IsRequired();

                    b.Navigation("TwitchUser");
                });
#pragma warning restore 612, 618
        }
    }
}
