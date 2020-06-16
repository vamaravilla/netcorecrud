using JobBoard.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace JobBoard.DataAccess
{
    public class JobBoardContext : DbContext
    {
        private readonly IConfiguration Configuration;

        /// <summary>
        /// Constructor using IConfiguration to get Connection string
        /// if null use InMemory
        /// </summary>
        /// <param name="configuration"></param>
        public JobBoardContext(IConfiguration configuration = null)
        {
            Configuration = configuration;
        }
        public DbSet<JobEntity> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                if(Configuration != null)
                {
                    // Configure DB Context for SQL Server
                    string connectionString = ConfigurationExtensions.GetConnectionString(this.Configuration, "JobBoardConnectionString");
                    options.UseSqlServer(connectionString);
                }
                else
                {
                    // If configure object is null use DB in Memory
                    options.UseInMemoryDatabase("JobBoardDB");
                }
              
            }
        }

    }
}
