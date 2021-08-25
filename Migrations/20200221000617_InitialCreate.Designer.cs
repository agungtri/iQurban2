﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iQurban.Data;

namespace iQurban.Migrations
{
    [DbContext(typeof(qurbanContext))]
    [Migration("20200221000617_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("iQurban.Models.Hewan", b =>
                {
                    b.Property<int>("HewanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Additional_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Berat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Harga")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Jenis_Hewan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HewanID");

                    b.ToTable("Hewans");
                });

            modelBuilder.Entity("iQurban.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HewanID")
                        .HasColumnType("int");

                    b.Property<int>("Jumlah")
                        .HasColumnType("int");

                    b.Property<string>("Keterangan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order_Number")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tanggal_Order")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("iQurban.Models.People", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alamat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Handphone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id_Kartu_Keluarga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIK")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tanggal_Lahir")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tempat_Lahir")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("iQurban.Models.User", b =>
                {
                    b.Property<string>("USERID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ACCESS_LEVEL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMAILID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FIRST_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LAST_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PASSWORD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PHONE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("READ_ONLY")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WRITE_ACCESS")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("USERID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}