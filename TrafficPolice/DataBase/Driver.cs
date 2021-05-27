using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrafficPolice
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriverID { get; set; }
        // public string Photo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public byte[] Photo { get; set; }
        public List<DriversLicense> driversLicenses { get; set; }
        public Passport Passport { get; set; }
        public List<Car> Cars { get; set; }

    }
}
