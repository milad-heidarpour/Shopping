﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopping.Database.Context;

#nullable disable

namespace Shopping.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231120153850_AddBrandLogoModel")]
    partial class AddBrandLogoModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Shopping.Database.Model.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandDes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandEnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandFaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NotShow")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Shopping.Database.Model.BrandLogo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("BrandLogos");
                });

            modelBuilder.Entity("Shopping.Database.Model.Commodity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Introduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<bool>("NotShow")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProductClassificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductEnName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductFaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegisterDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ProductClassificationId");

                    b.ToTable("Commodities");
                });

            modelBuilder.Entity("Shopping.Database.Model.ProductClassification", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GroupDes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupEnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupFaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NotShow")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ProductClassifications");
                });

            modelBuilder.Entity("Shopping.Database.Model.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleEnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleFaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe3b1c0f-e7af-4b7a-ae4d-3f50e8b9bd12"),
                            RoleEnName = "Admin",
                            RoleFaName = "مدیر"
                        },
                        new
                        {
                            Id = new Guid("8cdcf8e1-7300-42fb-b27b-0c981454da97"),
                            RoleEnName = "User",
                            RoleFaName = "کاربر"
                        });
                });

            modelBuilder.Entity("Shopping.Database.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumb")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("RePassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegisterDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bd9495f2-e361-40b9-b810-7234e1754152"),
                            FName = "میلاد",
                            Gender = "مرد",
                            LName = "حیدرپور",
                            Password = "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93",
                            PhoneNumb = "09030826556",
                            RePassword = "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93",
                            RegisterDate = "1402/08/29 19:08:49",
                            RoleId = new Guid("fe3b1c0f-e7af-4b7a-ae4d-3f50e8b9bd12")
                        });
                });

            modelBuilder.Entity("Shopping.Database.Model.BrandLogo", b =>
                {
                    b.HasOne("Shopping.Database.Model.Brand", "Brand")
                        .WithMany("BrandLogos")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Shopping.Database.Model.Commodity", b =>
                {
                    b.HasOne("Shopping.Database.Model.Brand", "Brand")
                        .WithMany("Commodities")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopping.Database.Model.ProductClassification", null)
                        .WithMany("Commodities")
                        .HasForeignKey("ProductClassificationId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Shopping.Database.Model.User", b =>
                {
                    b.HasOne("Shopping.Database.Model.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Shopping.Database.Model.Brand", b =>
                {
                    b.Navigation("BrandLogos");

                    b.Navigation("Commodities");
                });

            modelBuilder.Entity("Shopping.Database.Model.ProductClassification", b =>
                {
                    b.Navigation("Commodities");
                });

            modelBuilder.Entity("Shopping.Database.Model.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}