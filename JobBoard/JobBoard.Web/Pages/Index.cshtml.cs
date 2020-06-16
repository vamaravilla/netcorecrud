using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JobBoard.Entities;
using Microsoft.Extensions.Configuration;
using JobBoard.BusinessLogic;

namespace JobBoard.Web.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Business Logic Object to Backend CRUD Operations
        /// </summary>
        private JobBusinessLogic logic;
        public IList<JobEntity> JobEntity { get; set; }

        public IndexModel(IConfiguration configuration)
        {
            logic = new JobBusinessLogic(configuration);
        }

        public async Task OnGetAsync()
        {
            JobEntity = await logic.ListJobs();
        }
    }
}
