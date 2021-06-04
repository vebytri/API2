using API2.Models;
using API2.ViewModels;
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
        public DbSet<AcountRole> AcountRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        //set relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne<Acount>(a => a.Account).WithOne(p => p.Personn).HasForeignKey<Acount>(ac=>ac.NIK);
            modelBuilder.Entity<Acount>()
                .HasOne<Profiling>(p => p.Profilingg).WithOne(a => a.Account).HasForeignKey<Profiling>(ap => ap.NIK);
            modelBuilder.Entity<Profiling>()
                .HasOne(e => e.Education).WithMany(p => p.Profilingg);
            modelBuilder.Entity<University>()
                .HasMany(p => p.Education).WithOne(a => a.University);
            //set primary key
            modelBuilder.Entity<AcountRole>()
                .HasKey(ar => new { ar.NIK, ar.RoleId });
            //many to  many
            modelBuilder.Entity<AcountRole>()
                .HasOne(acount => acount.Acount)
                .WithMany(ar => ar.AcountRole)
                .HasForeignKey(acount => acount.NIK);
            modelBuilder.Entity<AcountRole>()
                .HasOne(role => role.Roles)
                .WithMany(ar => ar.AcountRoles)
                .HasForeignKey(role => role.RoleId);


        }
    }
}
