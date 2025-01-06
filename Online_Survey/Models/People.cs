using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Survey.Models
{
    public class People
    {
        [Key]
        public int P_no { get; set; } // Primary Key

        [Required]
        [StringLength(100)] // Limit name length to 100 characters
        public string? Name { get; set; }

        [Required]
        [StringLength(15)] // Phone number (e.g., max 15 digits)
        public string? Tell { get; set; }

        [Required]
        [EmailAddress] // Ensures valid email format
        public string? Email { get; set; }

        [Required]
        [StringLength(10)] // Male/Female/Other
        public string? Gender { get; set; }

        // Foreign Key
        [ForeignKey("Address")]
        public int Add_no { get; set; }

        public Address? Address { get; set; } // Navigation property

        [DataType(DataType.Date)] // Ensures Date format
        public DateTime Reg_date { get; set; }
    }
}
