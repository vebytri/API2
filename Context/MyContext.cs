using API2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base (options)
        {

        }
        //set table database
        public DbSet<Person> Persons { get; set; }
        public DbSet<Acount> Acounts { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }
        //set relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne<Acount>(a => a.Account).WithOne(p => p.Personn).HasForeignKey<Acount>(ac=>ac.NIK);
            modelBuilder.Entity<Acount>()
                .HasOne<Profiling>(p => p.Profilingg).WithOne(a => a.Account).HasForeignKey<Profiling>(ap => ap.NIK);
            modelBuilder.Entity<Profiling>()
                .HasOne<Education>(e => e.Edu).WithMany(p => p.Profilingg);
            modelBuilder.Entity<Education>()
                .HasOne<University>(p => p.Univ).WithMany(a => a.Edu);
        }
    }
}
