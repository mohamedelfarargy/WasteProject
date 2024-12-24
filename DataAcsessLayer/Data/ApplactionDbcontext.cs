using DataAcsessLayer.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAcsessLayer.Data
{
    public class ApplactionDbcontext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplactionDbcontext(DbContextOptions<ApplactionDbcontext> options) : base(options) { }
        // DbSets for the other entities
        public DbSet<WasteType> WasteTypes { get; set; }
        public DbSet<RecyclingRequest> RecyclingRequests { get; set; }
        public DbSet<Collector> Collectors { get; set; }
        public DbSet<VerificationCode> VerificationCodes { get; set; }

        // OnModelCreating method to configure relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  // Ensure Identity tables are created correctly

            // Configuring one-to-many relationship between User and RecyclingRequest
            modelBuilder.Entity<RecyclingRequest>()
                .HasOne(r => r.User)
                .WithMany(u => u.RecyclingRequests)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete to keep user data safe

            // Configuring one-to-many relationship between WasteType and RecyclingRequest
            modelBuilder.Entity<RecyclingRequest>()
                .HasOne(r => r.WasteType)
                .WithMany(w => w.RecyclingRequests)
                .HasForeignKey(r => r.WasteTypeId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent cascade delete

            // Configuring one-to-many relationship between User and VerificationCode
            modelBuilder.Entity<VerificationCode>()
                .HasOne(v => v.User)
                .WithMany(u => u.VerificationCodes)
                .HasForeignKey(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}