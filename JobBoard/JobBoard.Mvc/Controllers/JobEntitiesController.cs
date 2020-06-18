using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoard.Entities;
using Microsoft.Extensions.Logging;
using JobBoard.BusinessLogic;
using JobBoard.Mvc.Models;

namespace JobBoard.Mvc.Controllers
{
    public class JobEntitiesController : Controller
    {
        private readonly ILogger<JobEntitiesController> _logger;
        private JobBusinessLogic jobslogic;

        public JobEntitiesController(ILogger<JobEntitiesController> logger)
        {
            _logger = logger;
            jobslogic = new JobBusinessLogic();
        }

        /*
        // GET: JobEntities
        public async Task<IActionResult> Index()
        {
            return View(await jobslogic.ListJobs());
        }*/


        // GET: JobEntities
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {

            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            var jobsTask = await jobslogic.ListJobs();
            var jobs = jobsTask.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(s => s.Title.Contains(searchString,StringComparison.InvariantCultureIgnoreCase));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    jobs = jobs.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    jobs = jobs.OrderBy(s => s.CreatedAt);
                    break;
                case "date_desc":
                    jobs = jobs.OrderByDescending(s => s.CreatedAt);
                    break;
                default:
                    jobs = jobs.OrderBy(s => s.Description);
                    break;
            }

            int pageSize = 7;
            return View(PaginatedList<JobEntity>.Create(jobs.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        // GET: JobEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEntity = await jobslogic.GetJob((int)id);

            if (jobEntity == null)
            {
                return NotFound();
            }

            return View(jobEntity);
        }

        // GET: JobEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,Title,Description,CreatedAt,ExpiresAt")] JobEntity jobEntity)
        {
            if (ModelState.IsValid)
            {
                await jobslogic.CreateJob(jobEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(jobEntity);
        }

        // GET: JobEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEntity = await jobslogic.GetJob((int)id);
            if (jobEntity == null)
            {
                return NotFound();
            }
            return View(jobEntity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobId,Title,Description,CreatedAt,ExpiresAt")] JobEntity jobEntity)
        {
            if (id != jobEntity.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await jobslogic.UpdateJob(jobEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!jobslogic.JobExists(jobEntity.JobId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(jobEntity);
        }

        // GET: JobEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobEntity = await jobslogic.GetJob((int)id);
            if (jobEntity == null)
            {
                return NotFound();
            }

            return View(jobEntity);
        }

        // POST: JobEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobEntity = await jobslogic.GetJob(id);
            await jobslogic.DeleteJob(jobEntity);
            return RedirectToAction(nameof(Index));
        }


    }
}
