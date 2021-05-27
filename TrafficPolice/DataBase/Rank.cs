using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficPolice
{
    public class Rank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RankID { get; set; }
        public string RankName { get; set; }
        public string RankPhoto { get; set; }
        public List<Staff> Staffs { get; set; }

    }
}
