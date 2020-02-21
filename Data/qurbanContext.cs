using iQurban.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iQurban.Data
{
    public class qurbanContext : DbContext
    {
        public qurbanContext(DbContextOptions<qurbanContext> options) : base(options) { }

        public DbSet<Hewan> Hewans { get; set; }
        //public DbSet<People> Peoples { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<User> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Hewan>().ToTable("Hewan");
        //    modelBuilder.Entity<People>().ToTable("People");
        //    modelBuilder.Entity<Order>().ToTable("Order");
        //    modelBuilder.Entity<User>().ToTable("User");
        //}
    }
}
