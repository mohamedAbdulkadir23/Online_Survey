using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Survey.Models
{
     public class Survey
    {
        [Key]
        public int Survey_id { get; set; } // Primary Key, Auto Incremented

        [Required]
        [StringLength(255)]
        public string? Title { get; set; } // Title of the survey (Not Null)

        public string? Description { get; set; } // Description (Optional)

        [ForeignKey("User")]
        public int Created_by { get; set; } // Foreign Key to Users table
        public User? CreatedBy { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now; // Created date (Default: Current timestamp)

        public DateTime End_date { get; set; } // Updated date (Nullable)

        // Navigation Property
       
    }
}
