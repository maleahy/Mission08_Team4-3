using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team4_3.Models
{
    public class Todo
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Task { get; set; }
        public DateTime? Due_Date { get; set; }
        [Required]
        public string Quadrant { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool Completed { get; set; }
    }
}
