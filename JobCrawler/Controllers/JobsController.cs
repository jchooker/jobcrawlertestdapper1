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
        public IActionResult Index()
        {
            return View();
        }
    }
}
