using JobBoard.DataAccess;
using JobBoard.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.BusinessLogic
{
    public class JobBusinessLogic
    {
        private readonly IConfiguration Configuration;

        /// <summary>
        /// Constructor using IConfiguration to get Connection string
        /// if null use InMemory
        /// </summary>
        /// <param name="configuration"></param>
        public JobBusinessLogic(IConfiguration configuration = null)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// List all jobs
        /// </summary>
        /// <returns>List of Job objects</returns>
        public async Task<List<JobEntity>> ListJobs()
        {
            using var db = new JobBoardContext(Configuration);
            return await db.Jobs.ToListAsync();
        }

        /// <summary>
        /// Get a job by ID
        /// </summary>
        /// <returns>Job object</returns>
        public async Task<JobEntity> GetJob(int idJob)
        {
            using var db = new JobBoardContext(Configuration);
            return await db.Jobs.FirstOrDefaultAsync(m => m.JobId == idJob);
        }

        /// <summary>
        /// Get a job by ID
        /// </summary>
        /// <returns>Job object</returns>
        public JobEntity GetJobSync(int idJob)
        {
            using var db = new JobBoardContext(Configuration);
            return db.Jobs.FirstOrDefault(m => m.JobId == idJob);
        }

        /// <summary>
        /// Check if a job exists
        /// </summary>
        /// <returns>boolean</returns>
        public bool JobExists(int idJob)
        {
            using var db = new JobBoardContext(Configuration);
            return db.Jobs.Any(e => e.JobId == idJob);
        }


        /// <summary>
        /// Create a new Job
        /// </summary>
        /// <param name="newJob">New Job object</param>
        public async Task<int> CreateJob(JobEntity newJob)
        {
            using var db = new JobBoardContext(Configuration);
            db.Jobs.Add(newJob);
            return await db.SaveChangesAsync();
        }

        /// <summary>
        /// Update a job
        /// </summary>
        /// <param name="job">Job object</param>
        public async Task<int> UpdateJob(JobEntity oJob)
        {
            using var db = new JobBoardContext(Configuration);
            db.Attach(oJob).State = EntityState.Modified;
            //db.Jobs.Update(oJob);
            return await db.SaveChangesAsync();
        }

        /// <summary>
        /// Delete Job
        /// </summary>
        /// <param name="job">Job object</param>
        public async Task<int> DeleteJob(JobEntity job)
        {
            using var db = new JobBoardContext(Configuration);
            db.Jobs.Remove(job);
            return await db.SaveChangesAsync();
        }
    }
}
