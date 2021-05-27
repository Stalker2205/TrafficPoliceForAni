using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficPolice
{
    public class DriversLicense
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriversLicenseID { get; set; }
        public int DriversLicenseNumber { get; set; }
        public int DriversLicenseSeries { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int DriverID { get; set; }
        public Driver Driver { get; set; }
        public List<DriverKategoryLicence> DriverKategory { get; set; }
    }
}


