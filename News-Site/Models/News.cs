using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace News_Site.Models
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public string? NewsTitle { get; set; }
        public string? Body { get; set; }
        public DateTime Date { get; set; }
        public string? ImagePath { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public Category? Category { get; set; }

       public News()
        {
            Category = new Category();
        }
    } 
}
