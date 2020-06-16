using JobBoard.BusinessLogic;
using JobBoard.Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace JobBoard.Test
{
    public class JobTest
    {


        [Fact]
        public async Task Test_BL_CreateJob()
        {
            //Arrange
            JobBusinessLogic businessLogic = new JobBusinessLogic();
            JobEntity newjob = new JobEntity()
            {
                JobId = 1,
                Title = "Backend Senior Developer",
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(30)
            };

            //Act
            await businessLogic.CreateJob(newjob);
            var exists = businessLogic.JobExists(newjob.JobId);

            //Assert
            Assert.True(exists, "Job created");

        }

        [Fact]
        public async Task Test_BL_ListJobs()
        {
            //Arrange
            JobBusinessLogic businessLogic = new JobBusinessLogic();

            //Act
            JobEntity newjob1 = new JobEntity()
            {
                JobId = 1,
                Title = ".Net Developer",
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(30)
            };
            await businessLogic.CreateJob(newjob1);
            JobEntity newjob2 = new JobEntity()
            {
                JobId = 2,
                Title = "Backend Senior Developer",
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(30)
            };
            await businessLogic.CreateJob(newjob2);
            var list = await businessLogic.ListJobs();

            //Assert
            Assert.True(list.Count == 2,$"{list.Count} Jobs listed");

        }
    }
}
