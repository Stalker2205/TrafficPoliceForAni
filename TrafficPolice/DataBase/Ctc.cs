using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficPolice
{
    public class Ctc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("Car")]
        public int CtcID { get; set; }
        public int CtcNumber { get; set; }
        public string CtcSeries { get; set; }
        public int Owner { get; set; }
        public DateTime DateOfIssue { get; set; }
        public Car Car { get; set; }

    }
}
