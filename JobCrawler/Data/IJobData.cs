using JobCrawler.Models;

namespace JobCrawler.Data;
public interface IJobData
{
    Task DeleteJob(int id);
    Task<Job?> GetJob(int id);
    Task<IEnumerable<Job>> GetJobs();
    Task InsertJob(Job job);
    Task UpdateJob(Job job);
}