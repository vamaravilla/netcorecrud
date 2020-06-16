using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JobBoard.DataAccess;
using JobBoard.Entities;
using JobBoard.BusinessLogic;
using Microsoft.Extensions.Configuration;

namespace JobBoard.Web.Pages
{
    public class CreateModel : PageModel
    {
        /// <summary>
        /// Business Logic Object to Backend CRUD Operations
        /// </summary>
        private JobBusinessLogic logic;
        [BindProperty]
        public JobEntity JobEntity { get; set; }

        public CreateModel(IConfiguration configuration)
        {
            logic = new JobBusinessLogic(configuration);
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await logic.CreateJob(JobEntity);

            return RedirectToPage("./Index");
        }
    }
}
