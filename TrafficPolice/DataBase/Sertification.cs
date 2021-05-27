using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficPolice
{
    public class Sertification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SertificationID { get; set; }
        public int SertificationNumber { get; set; }
        public int SertificationSeries { get; set; }
        public string SertificationPosition { get; set; }
        public DateTime ValidUnit { get; set; }
        public Staff Staff { get; set; }
        public int StaffID { get; set; }

    }
}
