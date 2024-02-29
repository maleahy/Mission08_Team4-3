using System.ComponentModel.DataAnnotations;

namespace Mission08_Team4_3.Models
{
    public class Todos
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Task { get; set; }
        public DateTime Due_Date { get; set; }
        [Required]
        public string Quadrant { get; set; }
        public string Category { get; set; }
        public bool Completed { get; set; }
    }
}
