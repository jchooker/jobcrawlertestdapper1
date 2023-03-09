using Dapper;
using JobCrawler.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web;

namespace JobCrawler.Controllers
{
    public class JobsController : Controller
    {
        private static List<Job> jobs = new List<Job>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JobInputPartial() 
        {
            return PartialView("_JobInput", jobs);
        }
    }
}
