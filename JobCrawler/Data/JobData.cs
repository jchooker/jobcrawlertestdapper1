using JobCrawler.DbAccess;
using JobCrawler.Models;

namespace JobCrawler.Data
{
    public class JobData
    {
        private readonly ISqlDataAccess _db;

        public JobData(ISqlDataAccess db)
        {
            _db = db;
        }
        //METHODS for talking to db follow:
        public Task<IEnumerable<Job>> GetJobs() =>
            _db.LoadData<Job, dynamic>("dbo.spJob_GetAll", new { });
    }
}
