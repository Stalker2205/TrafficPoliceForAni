using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficPolice
{
    public class Statement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatementsID { get; set; }
        public string Applicant { get; set; }
        public string Cause { get; set; }
        public string Act { get; set; }
        public Car Car { get; set; }
        public int CarID { get; set; }
    }
}
