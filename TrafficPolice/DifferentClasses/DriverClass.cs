using System.Collections.Generic;

namespace TrafficPolice
{
    public class DriverClass
    {
        public static Dictionary<string, bool> LoadCategory()
        {
            Dictionary<string, bool> Category = new Dictionary<string, bool>();
            Category.Add("A", false); Category.Add("A1", false);
            Category.Add("B", false); Category.Add("B1", false);
            Category.Add("C", false); Category.Add("C1", false);
            Category.Add("D", false); Category.Add("D1", false);
            Category.Add("BE", false); Category.Add("DE", false);
            Category.Add("C1E", false); Category.Add("D1E", false);
            Category.Add("M", false); Category.Add("Tm", false);
            Category.Add("Tb", false);
            return Category;
        }
        public static int? DriverID = 1;
        public static string DriverDictinary = string.Empty;
        public static bool key = false;




    }
}
