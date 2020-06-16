using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JobBoard.DataAccess;
using JobBoard.Entities;
using JobBoard.BusinessLogic;
using Microsoft.Extensions.Configuration;

namespace JobBoard.Web.Pages
{
    public class DeleteModel : PageModel
    {
        /// <summary>
        /// Business Logic Object to Backend CRUD Operations
        /// </summary>
        private JobBusinessLogic logic;
        [BindProperty]
        public JobEntity JobEntity { get; set; }

        public DeleteModel(IConfiguration configuration)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobEntity = await logic.GetJob((int)id);

            if (JobEntity != null)
            {

                await logic.DeleteJob(JobEntity);
            }

            return RedirectToPage("./Index");
        }
    }
}
