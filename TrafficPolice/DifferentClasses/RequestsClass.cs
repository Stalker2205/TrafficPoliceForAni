using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace TrafficPolice
{
    public class RequestsClass
    {
        public static int? PackageDocuments;
        public static int? Driver;
        public static bool keySerch = false;
        public static void CheckVIn(string Vin)
        {
            keySerch = false;
            if (Vin.Length != 17) { MessageBox.Show("Длина vin - 17 символов"); return; }
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Cars.Load();
                db.Cars.Local.Where(x => x.Vin == Vin);
                var ur = db.Cars.Where(x => x.Vin == Vin);
                foreach (Car car in ur) { PackageDocuments = car.CarID; ; Driver = car.DriverID; }
            }
            keySerch = true;
        }

        public static void CheckDriverLicence(string series, string number)
        {
            keySerch = false;
            int num;
            int ser;
            try
            {
                num = Convert.ToInt32(number);
                ser = Convert.ToInt32(series);
            }
            catch { MessageBox.Show("Серия и номер должны быть числами"); return; }

            if (series.Length == 0 || series.Length != 4 || number.Length == 0 || number.Length != 6)
            {
                MessageBox.Show("Серия должна состоять из 4 цифр \n Номер должен состоять из 6 цифр"); return;
            }

            using (MyDBconnection db = new MyDBconnection())
            {
                db.DriversLicenses.Load();
                db.Drivers.Load();
                var driveLicence = db.DriversLicenses.Local.Where(x => x.DriversLicenseSeries == ser && x.DriversLicenseNumber == num);
                foreach (DriversLicense DLIcence in driveLicence) { Driver = DLIcence.DriverID; }
            }
            keySerch = true;
        }
        public static void CheckPassport(string series, string number)
        {
            keySerch = false;
            int num;
            int ser;
            try
            {
                num = Convert.ToInt32(number);
                ser = Convert.ToInt32(series);
            }
            catch { MessageBox.Show("Серия и номер должны быть числами"); return; }

            if (series.Length == 0 || series.Length != 4 || number.Length == 0 || number.Length != 6)
            {
                MessageBox.Show("Серия должна состоять из 4 цифр \n Номер должен состоять из 6 цифр"); return;
            }

            using (MyDBconnection db = new MyDBconnection())
            {
                db.Passports.Load();
                db.Drivers.Load();
                var pass = db.Passports.Local.Where(x => x.PassportSeries == ser && x.PassportNumber == num);
                foreach (Passport passport in pass) { Driver = passport.PassportID; }
            }
            keySerch = true;
        }
        public static void CheckIncurance(string series, string number)
        {
            keySerch = false;
            int num;
            int ser;
            try
            {
                num = Convert.ToInt32(number);
                ser = Convert.ToInt32(series);
            }
            catch { MessageBox.Show("Серия и номер должны быть числами"); return; }

            if (series.Length == 0 || series.Length != 3 || number.Length == 0 || number.Length != 10)
            {
                MessageBox.Show("Серия должна состоять из 3 цифр \n Номер должен состоять из 10 цифр"); return;
            }

            using (MyDBconnection db = new MyDBconnection())
            {
                //db.Insurances.Load();
                db.Drivers.Load();
                db.Cars.Load();
                //var ins = db.Insurances.Local.Where(x => x.InsuranceSeries == ser && x.InsuranceNumber == num);
                //foreach (Insurance insurance in ins) { PackageDocuments = insurance.InsuranceID; }
                var car = db.Cars.Local.Where(x => x.CarID == PackageDocuments);
                foreach (Car car1 in car) { Driver = car1.DriverID; }
            }
            keySerch = true;
        }
        public static void CheckSTS(string series, string number)
        {
            keySerch = false;
            int num;
            try
            {
                num = Convert.ToInt32(number);
            }
            catch { MessageBox.Show(" номер должен быть числом"); return; }
            if (series.Length == 0 || series.Length != 4 || number.Length == 0 || number.Length != 6)
            {
                MessageBox.Show("Серия должна состоять из 4 символов \n Номер должен состоять из 6 цифр"); return;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                // db.Ctcs.Load();
                db.Drivers.Load();
                db.Cars.Load();
                // var ins = db.Ctcs.Local.Where(x => x.CtcSeries == series && x.CtcNumber == num);
                // foreach (Ctc ctc in ins) { PackageDocuments = ctc.CtcID; Driver = ctc.Owner; }
            }
            keySerch = true;
        }
        public static void CheckPts(string series, string number)
        {
            keySerch = false;
            int num;
            try
            {
                num = Convert.ToInt32(number);
            }
            catch { MessageBox.Show(" номер должен быть числом"); return; }
            if (series.Length == 0 || series.Length != 4 || number.Length == 0 || number.Length != 6)
            {
                MessageBox.Show("Серия должна состоять из 4 символов \n Номер должен состоять из 6 цифр"); return;
            }
            using (MyDBconnection db = new MyDBconnection())
            {
                // db.Ptcs.Load();
                db.Drivers.Load();
                db.Cars.Load();
                //var ins = db.Ptcs.Local.Where(x => x.PtcSeries == series && x.PtcNumber == num);
                //foreach (Ptc ptc in ins) { PackageDocuments = ptc.PtcID; }
                var car = db.Cars.Local.Where(x => x.CarID == PackageDocuments);
                foreach (Car car1 in car) { Driver = car1.DriverID; }
            }
            keySerch = true;
        }


    }
}
