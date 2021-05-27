using System;
using System.Collections.Generic;

namespace TrafficPolice
{
    public class DriverLicenceClass
    {
        public static string _name;
        public static string _lastname;
        public static string _patronimyc;
        public static string _dateofIssue;
        public static string _datestart;
        public static string _dateEnd;
        public static int _series;
        public static int _number;
        //  public static Dictionary<string, bool> _kategory;
        public static Dictionary<string, DateTime> _Date = new Dictionary<string, DateTime>();
        public static byte[] _photo;
        // Kategoryes.Add("A1", false);
        // Kategoryes.Add("B1", false);
        // Kategoryes.Add("C1", false);
        // Kategoryes.Add("D1", false);

        //Kategoryes.Add("BE", false); Kategoryes.Add("CE", false);
        //Kategoryes.Add("C1E", false); Kategoryes.Add("DE", false);
        //Kategoryes.Add("D1E", false);
        //
    }
}
