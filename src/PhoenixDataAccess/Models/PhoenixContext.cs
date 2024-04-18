using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PhoenixDataAccess.Models
{
    public partial class PhoenixContext : DbContext
    {
        public PhoenixContext()
        {
        }

        public PhoenixContext(DbContextOptions<PhoenixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<Guest> Guests { get; set; } = null!;
        public virtual DbSet<Inventory> Inventories { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomInventory> RoomInventories { get; set; } = null!;
        public virtual DbSet<RoomService> RoomServices { get; set; } = null!;

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                 optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Phoenix; Trusted_Connection=True;User=sa;Password=indocyber; TrustServerCertificate=True");
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Administ__F3DBC5734BD073D6");

                entity.ToTable("Administrator");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("job_title")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("password")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Guest__F3DBC573B56E3A5E");

                entity.ToTable("Guest");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.Citizenship)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("citizenship")
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name")
                    .IsFixedLength();

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("gender")
                    .IsFixedLength();

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("id_number")
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name")
                    .IsFixedLength();

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("middle_name")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("password")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Inventor__72E12F1AB19BCF56");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("description")
                    .IsFixedLength();

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Reservat__357D4CF890E870E2");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code")
                    .IsFixedLength();

                entity.Property(e => e.BookDate)
                    .HasColumnType("datetime")
                    .HasColumnName("book_date");

                entity.Property(e => e.CheckIn)
                    .HasColumnType("datetime")
                    .HasColumnName("check_in");

                entity.Property(e => e.CheckOut)
                    .HasColumnType("datetime")
                    .HasColumnName("check_out");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(12, 2)")
                    .HasColumnName("cost");

                entity.Property(e => e.GuestNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("guest_number")
                    .IsFixedLength();

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("payment_date");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("payment_method")
                    .IsFixedLength();

                entity.Property(e => e.Remark)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("remark")
                    .IsFixedLength();

                entity.Property(e => e.ReservationMethod)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("reservation_method")
                    .IsFixedLength();

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("room_number")
                    .IsFixedLength();

                entity.HasOne(d => d.GuestNumberNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.GuestNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Guest");

                entity.HasOne(d => d.RoomNumberNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.RoomNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Resevations_Rooms");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Number)
                    .HasName("PK__Rooms__FD291E400B832CE0");

                entity.Property(e => e.Number)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("number")
                    .IsFixedLength();

                entity.Property(e => e.Cost)
                    .HasColumnType("money")
                    .HasColumnName("cost");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Floor).HasColumnName("floor");

                entity.Property(e => e.GuestLimit).HasColumnName("guest_limit");

                entity.Property(e => e.RoomType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("room_type");
            });

            modelBuilder.Entity<RoomInventory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InventoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("inventory_name")
                    .IsFixedLength();

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("room_number")
                    .IsFixedLength();

                entity.HasOne(d => d.InventoryNameNavigation)
                    .WithMany(p => p.RoomInventories)
                    .HasForeignKey(d => d.InventoryName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomInventory_Inventory");

                entity.HasOne(d => d.RoomNumberNavigation)
                    .WithMany(p => p.RoomInventories)
                    .HasForeignKey(d => d.RoomNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomInventory_Rooms");
            });

            modelBuilder.Entity<RoomService>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber)
                    .HasName("PK__RoomServ__8C453B0C6F9C191E");

                entity.Property(e => e.EmployeeNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("employee_number")
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("first_name")
                    .IsFixedLength();

                entity.Property(e => e.FridayRoasterFinish).HasColumnName("friday_roaster_finish");

                entity.Property(e => e.FridayRoasterStart).HasColumnName("friday_roaster_start");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name")
                    .IsFixedLength();

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("middle_name")
                    .IsFixedLength();

                entity.Property(e => e.MondayRoasterFinish).HasColumnName("monday_roaster_finish");

                entity.Property(e => e.MondayRoasterStart).HasColumnName("monday_roaster_start");

                entity.Property(e => e.OutsourcingCompany)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("outsourcing_company")
                    .IsFixedLength();

                entity.Property(e => e.SaturdatRoasterFinish).HasColumnName("saturdat_roaster_finish");

                entity.Property(e => e.SaturdayRoasterStart).HasColumnName("saturday_roaster_start");

                entity.Property(e => e.SundayRoasterFinish).HasColumnName("sunday_roaster_finish");

                entity.Property(e => e.SundayRoasterStart).HasColumnName("sunday_roaster_start");

                entity.Property(e => e.ThursdayRoasterFinish).HasColumnName("thursday_roaster_finish");

                entity.Property(e => e.ThursdayRoasterStart).HasColumnName("thursday_roaster_start");

                entity.Property(e => e.TuesdayRoasterFinish).HasColumnName("tuesday_roaster_finish");

                entity.Property(e => e.TuesdayRoasterStart).HasColumnName("tuesday_roaster_start");

                entity.Property(e => e.WednesdayRoasterFinish).HasColumnName("wednesday_roaster_finish");

                entity.Property(e => e.WednesdayRoasterStart).HasColumnName("wednesday_roaster_start");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
