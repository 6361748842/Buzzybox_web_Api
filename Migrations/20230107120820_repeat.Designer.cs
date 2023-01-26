﻿// <auto-generated />
using System;
using BuzzyBox_Web_Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuzzyBoxWebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230107120820_repeat")]
    partial class repeat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuzzyBox_Web_Api.Models.Authorization", b =>
                {
                    b.Property<string>("AuthorizationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorizationId");

                    b.ToTable("Authorization");
                });

            modelBuilder.Entity("BuzzyBox_Web_Api.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("Bookingdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Bookingtime")
                        .HasColumnType("datetime2");

                    b.Property<int>("BookingtypeId")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("FoodorderId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BuzzyBox_Web_Api.Models.Bookingtype", b =>
                {
                    b.Property<int>("BookingtypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingtypeId"));

                    b.Property<string>("Bookingtypename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingtypeId");

                    b.ToTable("Bookingtypes");
                });

            modelBuilder.Entity("BuzzyBox_Web_Api.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodId"));

                    b.Property<string>("Foodname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foodprice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("BuzzyBox_Web_Api.Models.Foodorder", b =>
                {
                    b.Property<int>("FoodorderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodorderId"));

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<string>("Foodname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foodordercost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Foodorderquntity")
                        .HasColumnType("int");

                    b.Property<string>("Foodprice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoodorderId");

                    b.ToTable("Foodorders");
                });

            modelBuilder.Entity("BuzzyBox_Web_Api.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BuzzyBox_Web_Api.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<string>("Transactionamount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Transactiondate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Transactiontime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Transactiontype")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactiontypeId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("BuzzyBox_Web_Api.Models.Transactiontype", b =>
                {
                    b.Property<int>("TransactiontypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactiontypeId"));

                    b.Property<string>("Transactiontypename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactiontypeId");

                    b.ToTable("Transactiontypes");
                });

            modelBuilder.Entity("BuzzyBox_Web_Api.Models.Users", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsersId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
