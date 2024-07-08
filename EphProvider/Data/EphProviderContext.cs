using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EphProvider.Models;

namespace EphProvider.Data
{
    public class EphProviderContext : DbContext
    {
        public EphProviderContext (DbContextOptions<EphProviderContext> options)
            : base(options)
        {
        }

        public DbSet<EphProvider.Models.NavMessage> NavMessage { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NavMessage>(entity =>
            {
                // Composite index for SvId, Week, and Tow columns
                entity.HasIndex(e => new { e.SvId, e.Week, e.Tow }).IsUnique(false);
            });
        }
        public DbSet<EphProvider.Models.User> User { get; set; } = default!;
        public DbSet<EphProvider.Models.PVT> PVT { get; set; } = default!;
        public DbSet<EphProvider.Models.Galileo> Galileo { get; set; } = default!;
    }
}
