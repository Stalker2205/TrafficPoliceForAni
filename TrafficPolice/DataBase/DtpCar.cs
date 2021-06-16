using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class DtpCar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DtpCarID { get; set; }
        public Car Car { get; set; }
        public int CarID { get; set; }
        public string Voditel { get; set; }
        public Dtp Dtp { get; set; }
        public int DtpID { get; set; }
        public string Conditions { get; set; }
        public string NameOfScheme { get; set; }

    }
}
