using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficPolice
{
    public class Ptc
    {
        [Key]
        [ForeignKey("Car")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PtcID { get; set; }
        public int PtcNumber { get; set; }
        public string PtcSeries { get; set; }
        public int YearOfManufacture { get; set; }
        public int EngineVolume { get; set; }
        public string EngineType { get; set; }
        public string EcoClass { get; set; }
        public string Manufacture { get; set; }
        public string CustomsRestrictions { get; set; }
        public string DateOut { get; set; }
        public Car Car { get; set; }

    }
}
