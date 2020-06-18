using JobBoard.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.Common;

namespace JobBoard.DataAccess
{
    public class JobBoardContext : DbContext
    {
        private readonly IConfiguration Configuration;
        private bool InMemory;
        /// <summary>
        /// Constructor using IConfiguration to get Connection string
        /// if null use local appsettings and save connection string
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="inMemory"></param>
        public JobBoardContext(IConfiguration configuration = null,bool inMemory = false)
        {
            Configuration = configuration;
            InMemory = inMemory;
        }
        public DbSet<JobEntity> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                if (InMemory)
                {
                    // If configure object is null use DB in Memory
                    options.UseInMemoryDatabase("JobBoardDB");
                    return;
                }
                if (Configuration != null)
                {
                    // Configure DB Context for SQL Server
                    string connectionString = ConfigurationExtensions.GetConnectionString(this.Configuration, "JobBoardConnectionString");
                    options.UseSqlServer(connectionString);
                }
                else
                {
                    if (ConnectionString == String.Empty)
                    {
                       
                        IConfigurationBuilder builder = new ConfigurationBuilder();
                        builder.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

                        // Configuration for SQL Server, but It can be any database  supported for EF
                        var root = builder.Build();
                        ConnectionString = root.GetConnectionString("JobBoardConnectionString");
                    }
                    options.UseSqlServer(ConnectionString);
                }

            }
        }

        /// <summary>
        /// Static propertie to save connection string
        /// </summary>
        public static string ConnectionString { get; set; } = String.Empty;

    }
}
