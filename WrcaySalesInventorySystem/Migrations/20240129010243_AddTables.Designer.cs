﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WrcaySalesInventorySystem.Data;

#nullable disable

namespace WrcaySalesInventorySystem.Migrations
{
    [DbContext(typeof(ApplicationDatabaseContext))]
    [Migration("20240129010243_AddTables")]
    partial class AddTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryDescription")
                        .HasMaxLength(300)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("category_description");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("inventory_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryID"));

                    b.Property<int>("DeliveryID")
                        .HasColumnType("int")
                        .HasColumnName("delivery_id");

                    b.Property<int>("StockIn")
                        .HasColumnType("int")
                        .HasColumnName("stock_in");

                    b.HasKey("InventoryID")
                        .HasName("pk_inventories");

                    b.ToTable("inventories", (string)null);
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<double>("ProductCost")
                        .HasColumnType("float")
                        .HasColumnName("product_cost");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(300)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("product_description");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("product_name");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float")
                        .HasColumnName("product_price");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int")
                        .HasColumnName("supplier_id");

                    b.HasKey("ProductID")
                        .HasName("pk_products");

                    b.HasIndex("CategoryID")
                        .HasDatabaseName("ix_products_category_id");

                    b.HasIndex("SupplierID")
                        .HasDatabaseName("ix_products_supplier_id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("role_name");

                    b.HasKey("RoleID")
                        .HasName("pk_roles");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.Sale", b =>
                {
                    b.Property<int>("SaleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sale_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME")
                        .HasColumnName("date");

                    b.Property<int>("ProductID")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<double>("Quantity")
                        .HasColumnType("float")
                        .HasColumnName("quantity");

                    b.HasKey("SaleID")
                        .HasName("pk_sales");

                    b.ToTable("sales", (string)null);
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusID"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("status_name");

                    b.HasKey("StatusID")
                        .HasName("pk_statuses");

                    b.ToTable("statuses", (string)null);
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sub_category_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategoryID"));

                    b.Property<string>("CategoryDescription")
                        .HasMaxLength(300)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("category_description");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("category_name");

                    b.HasKey("SubCategoryID")
                        .HasName("pk_sub_categories");

                    b.HasIndex("CategoryID")
                        .HasDatabaseName("ix_sub_categories_category_id");

                    b.ToTable("sub_categories", (string)null);
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("supplier_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"));

                    b.Property<string>("SupplierEmail")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("supplier_email");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("supplier_name");

                    b.Property<string>("SupplierPhone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("supplier_phone");

                    b.HasKey("SupplierID")
                        .HasName("pk_supplier");

                    b.ToTable("supplier", (string)null);
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("transaction_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionID"));

                    b.HasKey("TransactionID")
                        .HasName("pk_transactions");

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATE")
                        .HasColumnName("birth_date");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("password");

                    b.Property<int>("RoleID")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("user_name");

                    b.HasKey("UserID")
                        .HasName("pk_users");

                    b.HasIndex("RoleID")
                        .HasDatabaseName("ix_users_role_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.Product", b =>
                {
                    b.HasOne("WrcaySalesInventorySystem.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_categories_category_id");

                    b.HasOne("WrcaySalesInventorySystem.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_supplier_supplier_id");

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.SubCategory", b =>
                {
                    b.HasOne("WrcaySalesInventorySystem.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .HasConstraintName("fk_sub_categories_categories_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.User", b =>
                {
                    b.HasOne("WrcaySalesInventorySystem.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_roles_role_id");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WrcaySalesInventorySystem.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
