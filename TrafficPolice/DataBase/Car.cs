using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficPolice
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarID { get; set; }
        public string VenhicleType { get; set; }
        public int EngineNumber { get; set; }
        public int ChossisNumber { get; set; }
        public int BodyNumber { get; set; }
        public string Color { get; set; }
        public int MaxVeigh { get; set; }
        public string Vin { get; set; }
        public string Status { get; set; }
        public Driver Driver { get; set; }
        public int DriverID { get; set; }
        public Ptc Ptc { get; set; }
        public Insurance Insurance { get; set; }
        public Ctc Ctc { get; set; }
        public List<Inspection> Inspections { get; set; }
        public List<Statement> Statements { get; set; }
        public List<DtpCar> DtpCars { get; set; }
    }
}
