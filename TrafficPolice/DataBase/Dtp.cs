using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficPolice
{
    public class Dtp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DtpID { get; set; }
        public string Addres { get; set; }
        public DateTime DateDtp { get; set; }
        public string AccidentWitnesses { get; set; }
        public Staff Staff { get; set; }
        public int StaffID { get; set; }
        public List<DtpCar> DtpCars { get; set; }
        public byte[] DtpScheme { get; set; }
    }
}
