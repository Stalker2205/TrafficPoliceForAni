using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TrafficPolice
{
    class NewStaffClass
    {
        public static int id;
        public static bool key = false;
        public static bool serchID(string login, string password)
        {
            using (MyDBconnection db = new MyDBconnection())
            {
                db.Staffs.Load();
                if (db.Staffs.Local.Where(x => x.Login == login && x.Password == password).Count() != 0)
                {
                    id = db.Staffs.Local.Where(x => x.Login == login && x.Password == password).First().StaffID;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
