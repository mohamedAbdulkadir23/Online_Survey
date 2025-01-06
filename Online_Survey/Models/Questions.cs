using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Survey.Models
{
    public class Questions
    {
        [Key]
        public int Question_id { get; set; } // Primary Key, Auto Incremented

        [ForeignKey("Survey")]
        public int Survey_id { get; set; } // Foreign Key to Surveys table
        public Survey? Survey { get; set; }
        [Required]
        public string? Question_text { get; set; } // Question Text (Not Null)

        public DateTime Created_at { get; set; } = DateTime.Now; // Created date (Defaults to current timestamp)

        // Navigation Property
       
    }
}
