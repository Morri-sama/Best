using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.DbContexts
{
    public class BestDbContext : DbContext
    {
        public BestDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgeCategory>().HasData
            (
                new AgeCategory { Id = 1, Name = "От 3 до 5 лет", Priority = 1 },
                new AgeCategory { Id = 2, Name = "От 6 до 7 лет", Priority = 2 },
                new AgeCategory { Id = 3, Name = "От 8 до 10 лет", Priority = 3 },
                new AgeCategory { Id = 4, Name = "От 11 до 13 лет", Priority = 4 },
                new AgeCategory { Id = 5, Name = "От 14 до 16 лет", Priority = 5 },
                new AgeCategory { Id = 6, Name = "От 17 до 23 лет", Priority = 6 },
                new AgeCategory { Id = 7, Name = "От 24 лет и старше", Priority = 7 },
                new AgeCategory { Id = 8, Name = "Смешанная группа", Priority = 8 }
            );

            modelBuilder.Entity<TeacherType>().HasData
            (
                new TeacherType { Id = 1, Name = "Педагог" },
                new TeacherType { Id = 2, Name = "Преподаватель" },
                new TeacherType { Id = 3, Name = "Руководитель" }
            );


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Best;Trusted_Connection=True;");
            optionsBuilder.UseMySql(@"Server=km888.beget.tech; Database=km888_api; Uid=km888_api; Pwd=Zxcv1337_");
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<AgeCategory> AgeCategories { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Nomination> Nominations { get; set; }
        public DbSet<Subnomination> Subnominations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherType> TeacherTypes { get; set; }
        public DbSet<NominationAdditionalField> NominationAdditionalFields { get; set; }
        public DbSet<NominationAdditionalFieldValue> NominationAdditionalFieldValues { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}