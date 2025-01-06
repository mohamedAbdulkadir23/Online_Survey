using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Online_Survey.Models
{
    public class User
    {
        [Key]
        public int User_id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [ForeignKey("People")]
        public int P_no { get; set; }
        public People? People { get; set; }

        public string? User_type { get; set; }

        public DateTime Reg_date { get; set; }
    }
}
