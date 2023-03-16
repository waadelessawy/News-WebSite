using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News_Site.Data;
using News_Site.Models;
using Newtonsoft.Json;

namespace News_Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsAPIController : ControllerBase
    {

        private ApplicationDbContext _context { get; }

        public NewsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("GetAllNewsByCategoryID")]
        [HttpGet]
        public List<News> GetAllNewsByCategoryID(int categoryID)
        {
            if(categoryID <= 0)
            {
                return _context.News.ToList();
            }
            else
            {
                return _context.News.Where(a=>a.CategoryID == categoryID).ToList();
            }
           
        }

        [Route("GetNewsByID")]
        [HttpGet]
        public string GetNewsByID(int newsID)
        {
            var newsDetails = new News();
            newsDetails = _context.News.Include("Category").FirstOrDefault(a => a.NewsID == newsID);
      
            return JsonConvert.SerializeObject(newsDetails, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
           
        }
    }
}
