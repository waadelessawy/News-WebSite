using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News_Site.Data;
using News_Site.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace News_Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context { get; }

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //int id = 2;
      

            return View();
        }
        public List<News> GetAllNewsByCategoryID(int categoryID)
        {
            string apiUrl = "https://localhost:7149/api/NewsAPI";
            var news = new List<News>();

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl + string.Format("/GetAllNewsByCategoryID?categoryID={0}", categoryID)).Result;
            if (response.IsSuccessStatusCode)
            {
                news = JsonConvert.DeserializeObject<List<News>>(response.Content.ReadAsStringAsync().Result);
            }

            return news;

        }

        [HttpPost]
        public IActionResult NewsDetails(int newsID)
        {
            string apiUrl = "https://localhost:7149/api/NewsAPI";
            var newsDetails = new News();
            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(apiUrl + string.Format("/GetNewsByID?newsID={0}", newsID)).Result;
            if (response.IsSuccessStatusCode)
            {
                newsDetails = JsonConvert.DeserializeObject<News>(response.Content.ReadAsStringAsync().Result);
            }

            return View(newsDetails);
        }

        public List<Category> GetAllCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}