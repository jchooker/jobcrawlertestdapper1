using JobCrawler.DbAccess;
using JobCrawler.Models;

namespace JobCrawler.Data
{
    public class JobData : IJobData
    {
        private readonly ISqlDataAccess _db;

        public JobData(ISqlDataAccess db)
        {
            _db = db;
        }
        //METHODS for talking to db follow:
        public Task<IEnumerable<Job>> GetJobs() =>
            _db.LoadData<Job, dynamic>(storedProcedure: "dbo.spJob_GetAll", new { });

        public async Task<Job?> GetJob(int id)
        {
            var results = await _db.LoadData<Job, dynamic>(
                storedProcedure: "dbo.spJob_Get",
                new { Id = id });
            return results.FirstOrDefault(); //<-- will either return 1st record or null
        }

        public Task InsertJob(Job job) =>
            _db.SaveData(storedProcedure: "dbo.spJob_Insert", new { job.JobTitle, job.Organization, job.JobPlatform, job.Notes, job.Created });

        public Task UpdateJob(Job job) =>
            _db.SaveData(storedProcedure: "dbo.spJob_Update", job);

        public Task DeleteJob(int id) =>
            _db.SaveData(storedProcedure: "dbo.spJob_Delete", new { Id = id });
    }
}
