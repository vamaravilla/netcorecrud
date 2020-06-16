using JobBoard.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace JobBoard.DataAccess
{
    public class JobBoardMigrationContext : DbContext
    {
        public DbSet<JobEntity> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                IConfigurationBuilder builder = new ConfigurationBuilder();
                builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                // Configuration for SQL Server, but It can be any database  supported for EF
                var root = builder.Build();
                var sampleConnectionString = root.GetConnectionString("JobBoardConnectionString");
                options.UseSqlServer(sampleConnectionString);
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
                     },
                     new JobEntity
                     {
                         JobId = 3,
                         Title = "Backend Developer",
                         Description = "Backend Developer",
                         CreatedAt = DateTime.Now,
                         ExpiresAt = DateTime.Now.AddDays(30)
                     },
                     new JobEntity
                     {
                         JobId = 4,
                         Title = "Frontend Developer",
                         Description = "Frontend Developer",
                         CreatedAt = DateTime.Now,
                         ExpiresAt = DateTime.Now.AddDays(30)
                     },
                     new JobEntity
                     {
                         JobId = 5,
                         Title = "DevOps Engineer",
                         Description = "DevOps Engineer",
                         CreatedAt = DateTime.Now,
                         ExpiresAt = DateTime.Now.AddDays(30)
                     },
                     new JobEntity
                     {
                         JobId = 6,
                         Title = "Dev Manager",
                         Description = "Dev Manager",
                         CreatedAt = DateTime.Now,
                         ExpiresAt = DateTime.Now.AddDays(30)
                     },
                     new JobEntity
                     {
                         JobId = 7,
                         Title = "React Developer",
                         Description = "React Developer",
                         CreatedAt = DateTime.Now,
                         ExpiresAt = DateTime.Now.AddDays(30)
                     }

                );
        }
    }
}
