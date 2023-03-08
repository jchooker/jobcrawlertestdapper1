using System.ComponentModel.DataAnnotations;

namespace JobCrawler.Models
{
    public class Job
    {
        public Job() 
        { 
            Created = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string Organization { get; set; }
        public string JobPlatform { get; set; }
        public string? Notes { get; set; }
        public DateTime Created { get; set; }
    }
}
