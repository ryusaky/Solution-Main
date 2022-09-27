using System;
using Microsoft.EntityFrameworkCore;

namespace Solution.CoreApp.BetterPlan.Data.Models
{
    public class CallengueContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PortFolio> PortFolios { get; set; }
        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<FinancialEntity> FinancialEntities { get; set; }
        public virtual DbSet<GoalCategory> GoalCategories { get; set; }
        //public virtual DbSet<FinancialEntity> FinancialEntities { get; set; }
        public CallengueContext(DbContextOptions<CallengueContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Goal>()
                .HasOne(g => g.FinancialEntity)
                .WithMany(f => f.Goals)
                .HasForeignKey(g => g.financialentityid)
                .IsRequired(false);

            modelBuilder.Entity<Goal>()
                .HasOne(g => g.PortFolio)
                .WithMany(f => f.Goals)
                .HasForeignKey(g => g.portfolioid)
                .IsRequired(false);

        }
    }
}