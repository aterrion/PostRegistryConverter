using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PostReg
{
    public class City
    {
        public String Name;
        public String Region;
    }
    public static class Index
    {

        private static Dictionary<String, City> indexOfCity;
        private static Dictionary<String, String> cityOfIndex;
        private static Dictionary<String, String> cityOfRegion;

        public static void Load(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
        }


        public static bool Test(String indx)
        {
            if (indexOfCity.ContainsKey(indx))
                return true;
            return false;
        }

        public static City GetInfoFromIndex(String indx)
        {
            City city;
            if (indexOfCity.TryGetValue(indx, out city))  
                return city;
            return null;
        }
        public static String GetIndexFromCity(String city)
        {
            string indx;
            if (cityOfIndex.TryGetValue(city, out indx))
                return indx;
            return null;
        }
        public static String GetRegionFromCity(String city)
        {
            string region;
            if (cityOfRegion.TryGetValue(city, out region))
                return region;
            return null;
        }
    }
}
