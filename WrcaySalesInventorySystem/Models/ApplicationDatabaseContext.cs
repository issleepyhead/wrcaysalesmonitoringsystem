using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WrcaySalesInventorySystem.Models;

public partial class ApplicationDatabaseContext : DbContext
{
    public ApplicationDatabaseContext()
    {
    }

    public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tblcategory> Tblcategories { get; set; }

    public virtual DbSet<Tbldelivery> Tbldeliveries { get; set; }

    public virtual DbSet<Tbldiscount> Tbldiscounts { get; set; }

    public virtual DbSet<Tblinventory> Tblinventories { get; set; }

    public virtual DbSet<Tbllog> Tbllogs { get; set; }

    public virtual DbSet<Tblproduct> Tblproducts { get; set; }

    public virtual DbSet<Tblrole> Tblroles { get; set; }

    public virtual DbSet<Tblstatus> Tblstatuses { get; set; }

    public virtual DbSet<Tblsubcategory> Tblsubcategories { get; set; }

    public virtual DbSet<Tblsupplier> Tblsuppliers { get; set; }

    public virtual DbSet<Tbltransaction> Tbltransactions { get; set; }

    public virtual DbSet<Tbluser> Tblusers { get; set; }

    public virtual DbSet<Tblvat> Tblvats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\system\\wrcaysalesmonitoringsystem\\WrcaySalesInventorySystem\\wrcaysystemdb.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tblcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblcateg__3213E83F0D3B6191");

            entity.ToTable("tblcategories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category_description");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("category_name");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("date_added");
        });

        modelBuilder.Entity<Tbldelivery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3213E83F4E553E4E");

            entity.ToTable("tbldeliveries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("date_added");
            entity.Property(e => e.DeliveryDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("delivery_date");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reference_number");
            entity.Property(e => e.StatusId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("status_id");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Tbldeliveries)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__tbldelive__produ__16644E42");

            entity.HasOne(d => d.Status).WithMany(p => p.Tbldeliveries)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__tbldelive__statu__01142BA1");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Tbldeliveries)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__tbldelive__suppl__7F2BE32F");
        });

        modelBuilder.Entity<Tbldiscount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbldisco__3213E83FB70121F8");

            entity.ToTable("tbldiscount");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiscountName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("discount_name");
            entity.Property(e => e.DiscountValue).HasColumnName("discount_value");
        });

        modelBuilder.Entity<Tblinventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3213E83F2DCC09C4");

            entity.ToTable("tblinventory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateRecieved)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("date_recieved");
            entity.Property(e => e.DeliveryId).HasColumnName("delivery_id");
            entity.Property(e => e.StockIn).HasColumnName("stock_in");

            entity.HasOne(d => d.Delivery).WithMany(p => p.Tblinventories)
                .HasForeignKey(d => d.DeliveryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tblinvent__deliv__02084FDA");
        });

        modelBuilder.Entity<Tbllog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbllogs__3213E83F29D5E3C0");

            entity.ToTable("tbllogs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("action");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("date_added");
            entity.Property(e => e.ObjectActedOn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("object_acted_on");
            entity.Property(e => e.ObjectCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("object_category");
            entity.Property(e => e.TimeAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("time_added");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Tbllogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__tbllogs__user_id__51300E55");
        });

        modelBuilder.Entity<Tblproduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3213E83F32E9516B");

            entity.ToTable("tblproducts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_added");
            entity.Property(e => e.ProductCost).HasColumnName("product_cost");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_description");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductPrice).HasColumnName("product_price");

            entity.HasOne(d => d.Category).WithMany(p => p.Tblproducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__tblproduc__categ__15702A09");
        });

        modelBuilder.Entity<Tblrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblroles__3213E83F6DEB9F1B");

            entity.ToTable("tblroles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Tblstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblstatu__3213E83F4DB3C0C0");

            entity.ToTable("tblstatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<Tblsubcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblsubca__3213E83F2F573FE3");

            entity.ToTable("tblsubcategories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
        });

        modelBuilder.Entity<Tblsupplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblsuppl__3213E83F4E41ACCE");

            entity.ToTable("tblsuppliers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("date_added");
            entity.Property(e => e.SupplierAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("supplier_address");
            entity.Property(e => e.SupplierContact)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("supplier_contact");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("supplier_name");
        });

        modelBuilder.Entity<Tbltransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3213E83F5536B6CF");

            entity.ToTable("tbltransactions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("date_added");
            entity.Property(e => e.DiscountId).HasColumnName("discount_id");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("invoice_number");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VatId).HasColumnName("vat_id");

            entity.HasOne(d => d.Discount).WithMany(p => p.Tbltransactions)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbltransa__disco__4FF1D159");

            entity.HasOne(d => d.Product).WithMany(p => p.Tbltransactions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__tbltransa__produ__4E0988E7");

            entity.HasOne(d => d.User).WithMany(p => p.Tbltransactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__tbltransa__user___4D1564AE");

            entity.HasOne(d => d.Vat).WithMany(p => p.Tbltransactions)
                .HasForeignKey(d => d.VatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbltransa__vat_i__4EFDAD20");
        });

        modelBuilder.Entity<Tbluser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblusers__3213E83FE6CEF4A0");

            entity.ToTable("tblusers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Contact)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contact");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("date_created");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Tblusers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__tblusers__role_i__46E78A0C");
        });

        modelBuilder.Entity<Tblvat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblvat__3213E83F567972C8");

            entity.ToTable("tblvat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.VatName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vat_name");
            entity.Property(e => e.VatValue).HasColumnName("vat_value");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
