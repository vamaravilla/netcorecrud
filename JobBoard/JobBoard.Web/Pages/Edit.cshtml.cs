using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobBoard.Entities;
using JobBoard.BusinessLogic;
using Microsoft.Extensions.Configuration;

namespace JobBoard.Web.Pages
{
    public class EditModel : PageModel
    {
        /// <summary>
        /// Business Logic Object to Backend CRUD Operations
        /// </summary>
        private JobBusinessLogic logic;
        [BindProperty]
        public JobEntity JobEntity { get; set; }

        public EditModel(IConfiguration configuration)
        {
            logic = new JobBusinessLogic(configuration);
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobEntity = await logic.GetJob((int)id);

            if (JobEntity == null)
            {
                return NotFound();
            }
            return Page();
        }
         public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            try
            {
                await logic.UpdateJob(JobEntity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobEntityExists(JobEntity.JobId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JobEntityExists(int id)
        {
            return logic.JobExists(id);
        }
    }
}
