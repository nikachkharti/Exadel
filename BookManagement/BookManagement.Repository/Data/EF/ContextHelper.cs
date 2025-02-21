using BookManagement.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Repository.Data.EF
{
    public static class ContextHelper
    {
        public static void OverrideDefaultIdentityTableNames(this ModelBuilder modelBuilder)
        {
            // Override the default table names
            modelBuilder.Entity<ApplicationUser>(entity => { entity.ToTable(name: "Users"); });
            modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
            modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
        }

        public static void ConfigureBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                //Id
                entity.HasKey(b => b.Id);
                entity
                    .Property(b => b.Id)
                    .IsRequired();

                //Title
                modelBuilder.Entity<Book>()
                    .HasIndex(b => b.Title)
                    .IsUnique();
                entity
                    .Property(b => b.Title)
                    .HasMaxLength(100)
                    .IsRequired();

                //PublicationYear
                modelBuilder.Entity<Book>()
                    .Property(b => b.PublicationYear)
                    .IsRequired()
                    .HasColumnType("DATE");

                //ViewCount
                entity.Property(b => b.ViewCount)
                    .IsRequired();

                //AuthorName
                entity
                    .Property(a => a.AuthorName)
                    .IsRequired()
                    .HasMaxLength(100);

                //Age
                modelBuilder.Entity<Book>()
                    .Property(b => b.Age)
                    .HasComputedColumnSql("DATEDIFF(YEAR, PublicationYear, GETDATE())", stored: false);
            });
        }
        public static void SeedBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = Guid.Parse("EF924032-43A1-4531-AD96-5EE190790AF8"),
                    Title = "Three Musketers",
                    AuthorName = "Alexander Dumas",
                    PublicationYear = DateTime.Parse("1844-07-10"),
                    ViewCount = 5
                },
                new Book()
                {
                    Id = Guid.Parse("B6A80EDC-D005-47C6-8241-619109DA1504"),
                    Title = "The Brothers Karamazov",
                    AuthorName = "Fiodor Dostoevsky",
                    PublicationYear = DateTime.Parse("1880-11-01"),
                    ViewCount = 11
                },
                new Book()
                {
                    Id = Guid.Parse("522F3F16-5AE3-42EA-9C19-90995B097805"),
                    Title = "Don Quixote",
                    AuthorName = "Miguel de Cervantes",
                    PublicationYear = DateTime.Parse("1605-01-16"),
                    ViewCount = 9
                }
            );

        }
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            PasswordHasher<ApplicationUser> hasher = new();

            modelBuilder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser()
                    {
                        Id = "8716071C-1D9B-48FD-B3D0-F059C4FB8031",
                        UserName = "admin@gmail.com",
                        NormalizedUserName = "ADMIN@GMAIL.COM",
                        Email = "admin@gmail.com",
                        NormalizedEmail = "ADMIN@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = hasher.HashPassword(null, "Admin123!"),
                        PhoneNumber = "555337681",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new ApplicationUser()
                    {
                        Id = "D514EDC9-94BB-416F-AF9D-7C13669689C9",
                        UserName = "nika@gmail.com",
                        NormalizedUserName = "NIKA@GMAIL.COM",
                        Email = "nika@gmail.com",
                        NormalizedEmail = "NIKA@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = hasher.HashPassword(null, "Nika123!"),
                        PhoneNumber = "558490645",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    },
                    new ApplicationUser()
                    {
                        Id = "87746F88-DC38-4756-924A-B95CFF3A1D8A",
                        UserName = "gio@gmail.com",
                        NormalizedUserName = "GIO@GMAIL.COM",
                        Email = "gio@gmail.com",
                        NormalizedEmail = "GIO@GMAIL.COM",
                        EmailConfirmed = false,
                        PasswordHash = hasher.HashPassword(null, "Gio123!"),
                        PhoneNumber = "551442269",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnd = null,
                        LockoutEnabled = true,
                        AccessFailedCount = 0
                    }
                );
        }
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "33B7ED72-9434-434A-82D4-3018B018CB87", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "9C07F9F6-D3B0-458A-AB7F-218AA622FA5B", Name = "Customer", NormalizedName = "CUSTOMER" }
            );
        }
        public static void SeedUserRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string> { RoleId = "33B7ED72-9434-434A-82D4-3018B018CB87", UserId = "8716071C-1D9B-48FD-B3D0-F059C4FB8031" },
                    new IdentityUserRole<string> { RoleId = "9C07F9F6-D3B0-458A-AB7F-218AA622FA5B", UserId = "D514EDC9-94BB-416F-AF9D-7C13669689C9" },
                    new IdentityUserRole<string> { RoleId = "9C07F9F6-D3B0-458A-AB7F-218AA622FA5B", UserId = "87746F88-DC38-4756-924A-B95CFF3A1D8A" }
                );
        }

    }
}
