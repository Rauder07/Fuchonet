using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FuchonetAPI.Models;

namespace FuchonetAPI.DataAccess
{
    public partial class FuchonetDbContext : DbContext
    {
        public FuchonetDbContext()
        {
        }

        public FuchonetDbContext(DbContextOptions<FuchonetDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<ClientServiceHistory> ClientServiceHistories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<EventType> EventTypes { get; set; } = null!;
        public virtual DbSet<Ip> Ips { get; set; } = null!;
        public virtual DbSet<Ipshistory> Ipshistories { get; set; } = null!;
        public virtual DbSet<Phone> Phones { get; set; } = null!;
        public virtual DbSet<PhoneRelationship> PhoneRelationships { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceAgrement> ServiceAgrements { get; set; } = null!;
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
        public virtual DbSet<Zone> Zones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNTS", "SYSTEM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.ServiceAgrementId).HasColumnName("service_agrement_id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.ServiceAgrement)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ServiceAgrementId)
                    .HasConstraintName("FK__ACCOUNTS__servic__46B27FE2");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("ADDRESSES", "SYSTEM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Note)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.ZoneId).HasColumnName("zone_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ADDRESSES__custo__339FAB6E");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.ZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ADDRESSES__zone___32AB8735");
            });

            modelBuilder.Entity<ClientServiceHistory>(entity =>
            {
                entity.ToTable("CLIENT_SERVICE_HISTORY", "SYSTEM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EventDate)
                    .HasColumnType("date")
                    .HasColumnName("event_date");

                entity.Property(e => e.EventDescription)
                    .IsUnicode(false)
                    .HasColumnName("event_description");

                entity.Property(e => e.EventType).HasColumnName("event_type");

                entity.Property(e => e.ServiceAgrementId).HasColumnName("service_agrement_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.EventTypeNavigation)
                    .WithMany(p => p.ClientServiceHistories)
                    .HasForeignKey(d => d.EventType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLIENT_SE__event__42E1EEFE");

                entity.HasOne(d => d.ServiceAgrement)
                    .WithMany(p => p.ClientServiceHistories)
                    .HasForeignKey(d => d.ServiceAgrementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CLIENT_SE__servi__41EDCAC5");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMERS", "SYSTEM");

                entity.HasIndex(e => e.Dni, "dni_unique_notnull")
                    .IsUnique()
                    .HasFilter("([dni] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("dni")
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("EVENT_TYPE", "SYSTEM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Ip>(entity =>
            {
                entity.ToTable("IPS", "SYSTEM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IpAddress)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("ip_address");

                entity.Property(e => e.IpStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ip_status")
                    .HasDefaultValueSql("('LIBRE')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            modelBuilder.Entity<Ipshistory>(entity =>
            {
                entity.ToTable("IPSHISTORY", "SYSTEM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.IpId).HasColumnName("ip_id");

                entity.Property(e => e.ServiceAgrementId).HasColumnName("service_agrement_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Ip)
                    .WithMany(p => p.Ipshistories)
                    .HasForeignKey(d => d.IpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__IPSHISTOR__ip_id__55F4C372");

                entity.HasOne(d => d.ServiceAgrement)
                    .WithMany(p => p.Ipshistories)
                    .HasForeignKey(d => d.ServiceAgrementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__IPSHISTOR__servi__55009F39");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("PHONES", "SYSTEM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone_number")
                    .IsFixedLength();

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHONES__customer__02FC7413");
            });

            modelBuilder.Entity<PhoneRelationship>(entity =>
            {
                entity.ToTable("PHONE_RELATIONSHIP", "SYSTEM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("person_name");

                entity.Property(e => e.PhoneId).HasColumnName("phone_id");

                entity.Property(e => e.Relationship)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("relationship");

                entity.HasOne(d => d.Phone)
                    .WithMany(p => p.PhoneRelationships)
                    .HasForeignKey(d => d.PhoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHONE_REL__phone__5224328E");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("SERVICES", "SYSTEM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.ServiceCategoryId).HasColumnName("service_category_id");

                entity.HasOne(d => d.ServiceCategory)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ServiceCategoryId)
                    .HasConstraintName("FK__SERVICES__servic__1EA48E88");
            });

            modelBuilder.Entity<ServiceAgrement>(entity =>
            {
                entity.ToTable("SERVICE_AGREMENTS", "SYSTEM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.ContractMonth).HasColumnName("contract_month");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.CutoffDay).HasColumnName("cutoff_day");

                entity.Property(e => e.MonthlyFee)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("monthly_fee");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.Property(e => e.ServiceStartDate)
                    .HasColumnType("date")
                    .HasColumnName("service_start_date");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.ServiceAgrements)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SERVICE_A__addre__395884C4");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ServiceAgrements)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SERVICE_A__custo__3864608B");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceAgrements)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SERVICE_A__servi__37703C52");
            });

            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.ToTable("SERVICE_CATEGORIES", "SYSTEM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.ToTable("ZONES", "SYSTEM");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
