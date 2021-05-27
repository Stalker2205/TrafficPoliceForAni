using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficPolice
{
    public class Insurance
    {
        [Key]
        [ForeignKey("Car")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InsuranceID { get; set; }
        public int InsuranceNumber { get; set; }
        public int InsuranceSeries { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Insurant { get; set; }
        public Car Car { get; set; }

    }
}
