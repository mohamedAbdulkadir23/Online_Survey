using System.ComponentModel.DataAnnotations;

namespace Online_Survey.Models
{
    public class Address
    {
        [Key]
        public int Add_no { get; set; }


        public string? District { get; set; }

        public string? Village { get; set; }



    }
}
