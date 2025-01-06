using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Survey.Models
{
    public class Answers
    {
        [Key]
        public int Answer_id { get; set; } // Primary Key, Auto Incremented

        [ForeignKey("Questions")]
        public int Question_id { get; set; } // Foreign Key to Questions table
        public Questions? Questions { get; set; }
        public string? Answer_text { get; set; } // For open-ended or rating answers

        public DateTime Created_at { get; set; } = DateTime.Now; // Created date (Defaults to current timestamp)

        // Navigation Property
        
    }
}
