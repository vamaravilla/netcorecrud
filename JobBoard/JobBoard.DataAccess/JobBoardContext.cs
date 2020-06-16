using JobBoard.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace JobBoard.DataAccess
{
    public class JobBoardContext : DbContext
    {
        public DbSet<JobEntity> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseInMemoryDatabase("JobBoardDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobEntity>().HasData(
                    new JobEntity
                    {
                        JobId = 1,
                        Title = ".NET Developer",
                        Description = ".NET Developer",
                        CreatedAt = DateTime.Now,
                        ExpiresAt = DateTime.Now.AddDays(30)
                    },
                     new JobEntity
                     {
                         JobId = 2,
                         Title = "QA Analyst",
                         Description = "QA Analyst",
                         CreatedAt = DateTime.Now,
                         ExpiresAt = DateTime.Now.AddDays(30)
                     }
                );
        }
    }
}
