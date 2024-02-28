using System.ComponentModel.DataAnnotations;

namespace Mission08_Team4_3.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}
