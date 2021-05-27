using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficPolice
{
    public class Inspection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InspectionID { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime EndDate { get; set; }
        public string PlaceOfInspaction { get; set; }
        public string Vin { get; set; }
        public int ChossisNumber { get; set; }
        public int BodyNumber { get; set; }
        public string Model { get; set; }
        public string Malfunctions { get; set; }
        public bool UsingCar { get; set; }
        public Car Car { get; set; }
        public int CarID { get; set; }

    }
}
