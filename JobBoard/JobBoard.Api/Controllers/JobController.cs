using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoard.Entities;
using Microsoft.Extensions.Configuration;
using JobBoard.BusinessLogic;
using Microsoft.AspNetCore.Authorization;

namespace JobBoard.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private JobBusinessLogic logic;
        public JobController(IConfiguration config)
        {
            logic = new JobBusinessLogic(config);
        }

        /// <summary>
        /// List Jobs
        /// </summary>
        /// <returns>Array Jobs</returns>
        // GET: api/Job
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobEntity>>> GetJobs()
        {
            return await logic.ListJobs();
        }

        /// <summary>
        /// Get Job
        /// </summary>
        /// <param name="id">Id Job</param>
        /// <returns>job</returns>
        // GET: api/Job/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobEntity>> GetJob(int id)
        {
            var jobEntity = await logic.GetJob(id);

            if (jobEntity == null)
            {
                return NotFound();
            }

            return jobEntity;
        }

        /// <summary>
        /// Update Job
        /// </summary>
        /// <param name="id">id Job</param>
        /// <param name="jobEntity">obj Job</param>
        /// <returns>Result</returns>
        // PUT: api/Job/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, JobEntity jobEntity)
        {
            if (id != jobEntity.JobId)
            {
                return BadRequest();
            }

            try
            {
                await logic.UpdateJob(jobEntity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Create Job
        /// </summary>
        /// <param name="jobEntity">Object Job</param>
        /// <returns>Result</returns>
        // POST: api/Job/5
        [HttpPost]
        public async Task<ActionResult<JobEntity>> PostJob(JobEntity jobEntity)
        {

            await logic.CreateJob(jobEntity);

            return CreatedAtAction("GetJob", new { id = jobEntity.JobId }, jobEntity);
        }

        /// <summary>
        /// Delete Job
        /// </summary>
        /// <param name="id">Id job</param>
        /// <returns>Job Entity</returns>
        // DELETE: api/Job/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobEntity>> DeleteJob(int id)
        {
            var jobEntity = await logic.GetJob(id);
            if (jobEntity == null)
            {
                return NotFound();
            }

            await logic.DeleteJob(jobEntity);

            return jobEntity;
        }

        private bool JobExists(int id)
        {
            return logic.JobExists(id);
        }
    }
}
