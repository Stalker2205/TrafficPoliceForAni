using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficPolice
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffID { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public byte[] Photo { get; set; }
        public string Education { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public List<Sertification> Sertifications { get; set; }
        public int RankID { get; set; }
        List<Raports> Raports { get; set; }
        List<Dtp> Dtps { get; set; }

    }
}
