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
    [Migration("20240103143443_AddCommodityFeatureModel")]
    partial class AddCommodityFeatureModel
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

                    b.Property<string>("BrandImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NotShow")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Shopping.Database.Model.Commodity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<Guid>("GroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Introduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<bool>("NotShow")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductEnName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductFaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegisterDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdateDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("GroupId");

                    b.ToTable("Commodities");
                });

            modelBuilder.Entity("Shopping.Database.Model.CommodityAlbum", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommodityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommodityImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommodityId");

                    b.ToTable("CommoditiesAlbum");
                });

            modelBuilder.Entity("Shopping.Database.Model.CommodityFeature", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CommodityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CommodityId");

                    b.HasIndex("FeatureId");

                    b.ToTable("CommodityFeatures");
                });

            modelBuilder.Entity("Shopping.Database.Model.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FeatureSectionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeatureSectionId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Shopping.Database.Model.FeatureGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FeatureGroups");
                });

            modelBuilder.Entity("Shopping.Database.Model.FeatureSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FeatureGroupId")
                        .HasColumnType("int");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeatureGroupId");

                    b.ToTable("FeatureSections");
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
                        .IsRequired()
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
                            Id = new Guid("336e3c3d-34e2-4efd-83a2-cf0eaadd6bd5"),
                            RoleEnName = "Admin",
                            RoleFaName = "مدیر"
                        },
                        new
                        {
                            Id = new Guid("e00500a5-509a-404a-92d7-d5b484fc2a2b"),
                            RoleEnName = "User",
                            RoleFaName = "کاربر"
                        });
                });

            modelBuilder.Entity("Shopping.Database.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumb")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("ProfileImg")
                        .HasColumnType("nvarchar(max)");

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
                            Id = new Guid("cb1d0869-9eec-4bf5-8818-8a8c1d2252ee"),
                            FName = "میلاد",
                            Gender = "مرد",
                            LName = "حیدرپور",
                            Password = "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93",
                            PhoneNumb = "09030826556",
                            ProfileImg = "Admin.jpg",
                            RePassword = "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93",
                            RegisterDate = "1402/10/13 18:04:42",
                            RoleId = new Guid("336e3c3d-34e2-4efd-83a2-cf0eaadd6bd5")
                        });
                });

            modelBuilder.Entity("Shopping.Database.Model.Commodity", b =>
                {
                    b.HasOne("Shopping.Database.Model.Brand", "Brand")
                        .WithMany("Commodities")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopping.Database.Model.ProductClassification", "Group")
                        .WithMany("Commodities")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Shopping.Database.Model.CommodityAlbum", b =>
                {
                    b.HasOne("Shopping.Database.Model.Commodity", "Commodity")
                        .WithMany("CommodityAlbums")
                        .HasForeignKey("CommodityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commodity");
                });

            modelBuilder.Entity("Shopping.Database.Model.CommodityFeature", b =>
                {
                    b.HasOne("Shopping.Database.Model.Commodity", "Commodity")
                        .WithMany()
                        .HasForeignKey("CommodityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopping.Database.Model.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commodity");

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("Shopping.Database.Model.Feature", b =>
                {
                    b.HasOne("Shopping.Database.Model.FeatureSection", "FeatureSection")
                        .WithMany("Features")
                        .HasForeignKey("FeatureSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeatureSection");
                });

            modelBuilder.Entity("Shopping.Database.Model.FeatureSection", b =>
                {
                    b.HasOne("Shopping.Database.Model.FeatureGroup", "FeatureGroup")
                        .WithMany("FeatureSections")
                        .HasForeignKey("FeatureGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeatureGroup");
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
                    b.Navigation("Commodities");
                });

            modelBuilder.Entity("Shopping.Database.Model.Commodity", b =>
                {
                    b.Navigation("CommodityAlbums");
                });

            modelBuilder.Entity("Shopping.Database.Model.FeatureGroup", b =>
                {
                    b.Navigation("FeatureSections");
                });

            modelBuilder.Entity("Shopping.Database.Model.FeatureSection", b =>
                {
                    b.Navigation("Features");
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
