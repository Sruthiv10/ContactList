using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RFL.TechStack.Core.Entities;

namespace RFL.TechStack.Infrastructure.Repositories
{
    public partial class TECHDBContext : DbContext
    {
        public TECHDBContext()
        {
        }

        public TECHDBContext(DbContextOptions<TECHDBContext> options)
            : base(options)
        {
        }

        
        public virtual DbSet<PurchaseorderEntry> PurchaseorderEntries { get; set; } = null!;
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=TechStack;Integrated Security=SSPI; MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          

            modelBuilder.Entity<PurchaseorderEntry>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("purchaseorder_entries");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.AdditionalData)
                    .IsUnicode(false)
                    .HasColumnName("additional_data");

                entity.Property(e => e.BlobId)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("blob_id");

                entity.Property(e => e.DeliveryNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("delivery_number");

                entity.Property(e => e.EntryAdditionalData)
                    .IsUnicode(false)
                    .HasColumnName("entry_additional_data");

                entity.Property(e => e.EntryNumber).HasColumnName("entry_number");

                entity.Property(e => e.EntryProduct)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("entry_product");

                entity.Property(e => e.EntryQuantity).HasColumnName("entry_quantity");

                entity.Property(e => e.EntrySchLineNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("entry_sch_line_no");

                entity.Property(e => e.EntryUom)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("entry_uom");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("order_date");

                entity.Property(e => e.OrderNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("order_number");

                entity.Property(e => e.ProcessId)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("process_id");

                entity.Property(e => e.ProviderId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("provider_id");

                entity.Property(e => e.UserId)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("user_id");

                entity.Property(e => e.VendorId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("vendor_id");
            });

           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
