using System.ComponentModel.DataAnnotations;

namespace News_Site.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }

        public ICollection<News>? News  { get; set; }

        public Category()
        {
            News = new HashSet<News>();

        }
    }
}
