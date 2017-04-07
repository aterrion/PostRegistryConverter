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
        public String Index;
        public String Name;
        public String Region;
        public String State;
    }
    public static class Index
    {

        private static Dictionary<String, City> indexOfCity;
        private static List<City> allCity;

        /// <summary>
        /// Загрузка информации о индексах, городах и областях из файла конфигурации Укрпочты
        /// </summary>
        /// <param name="path">xml file</param>
        public static void Load(string path)
        {
            indexOfCity = new Dictionary<string, City>();
            allCity = new List<PostReg.City>();

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            var DICT_158 = doc.GetElementsByTagName("EXTDICT_158");
            XmlNode node_158 = (XmlNode)DICT_158[0].FirstChild.FirstChild;
            var DICT_125 = doc.GetElementsByTagName("EXTDICT_125");
            XmlNode node_125 = (XmlNode)DICT_125[0].FirstChild.FirstChild;
            var DICT_124 = doc.GetElementsByTagName("EXTDICT_124");
            XmlNode node_124 = (XmlNode)DICT_124[0].FirstChild.FirstChild;
            var DICT_123 = doc.GetElementsByTagName("EXTDICT_123");
            XmlNode node_123 = (XmlNode)DICT_123[0].FirstChild.FirstChild;

            Dictionary<String, String> _state = new Dictionary<string, string>();
            while(node_123!=null)
            {
                _state.Add(node_123.Attributes.GetNamedItem("f0").Value, node_123.Attributes.GetNamedItem("f1").Value);
                node_123 = node_123.NextSibling; 
            }
            Dictionary<String, String> _region = new Dictionary<string, string>();
            string tmp_state;
            string tmp_region;
            while (node_124 != null)
            {
                _region.Add(node_124.Attributes.GetNamedItem("f0").Value, node_124.Attributes.GetNamedItem("f1").Value);
                _state.TryGetValue(node_124.Attributes.GetNamedItem("f2").Value, out tmp_state);
                node_124 = node_124.NextSibling;
            }
            Dictionary<String, City> _city = new Dictionary<string, City>();
            City item;
            while (node_125 != null)
            {
                _region.TryGetValue(node_125.Attributes.GetNamedItem("f2").Value, out tmp_region);
                _state.TryGetValue(node_125.Attributes.GetNamedItem("f2").Value, out tmp_state);
                item = new City();
                item.Name = node_125.Attributes.GetNamedItem("f1").Value;
                item.Region = tmp_region;
                item.State = tmp_state;
                _city.Add(node_125.Attributes.GetNamedItem("f0").Value, item);
                node_125 = node_125.NextSibling;
            }
            while (node_158 != null)
            {
                _city.TryGetValue(node_158.Attributes.GetNamedItem("f2").Value, out item);
                item.Index = node_158.Attributes.GetNamedItem("f1").Value;
                allCity.Add(item);
                try {
                    indexOfCity.Add(node_158.Attributes.GetNamedItem("f1").Value, item);
                }
                catch (ArgumentException)
                {
                    node_158 = node_158.NextSibling;
                    continue;
                }
                node_158 = node_158.NextSibling;
            }
            _city = null;
            _region = null;
            _state = null;
            GC.Collect();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"> индекс</param>
        /// <param name="city">город</param>
        /// <param name="region">район</param>
        /// <param name="state">область</param>
        public static void Add(string index, string city, string region, string state)
        {
            City item = new City();
            item.Index = index;
            item.Name = city;
            item.Region = region;
            item.State = state;
            allCity.Add(item);
            try
            {
                indexOfCity.Add(index, item);
            }
            catch (ArgumentException)
            {
                //
            }
        }
        /// <summary>
        /// Загрузка из собстенного xml файла
        /// </summary>
        /// <param name="path">xml file</param>
        public static void Update(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            var ADD = doc.GetElementsByTagName("ADD");
            XmlNode node = (XmlNode)ADD[0].FirstChild;
            City item;
            while(node != null)
            {
                item = new City();
                item.Index = node.Attributes.GetNamedItem("index").Value;
                item.Name = node.Attributes.GetNamedItem("city").Value;
                item.Region = node.Attributes.GetNamedItem("region").Value;
                item.State = node.Attributes.GetNamedItem("state").Value;

                allCity.Add(item);
                try
                {
                    indexOfCity.Add(node.Attributes.GetNamedItem("index").Value, item);
                }
                catch (ArgumentException)
                {
                    node = node.NextSibling;
                    continue;
                }
                node = node.NextSibling;
            }
            
        }
        /// <summary>
        /// Проверка индекса
        /// </summary>
        /// <param name="indx">проверяемый индекс</param>
        /// <returns>true если такой индекс существует в базе</returns>
        public static bool Test(String indx)
        {
            if (indexOfCity.ContainsKey(indx))
                return true;
            return false;
        }
        /// <summary>
        /// Найти все населенные пункты по индексу
        /// </summary>
        /// <param name="indx">индекс</param>
        /// <returns>Все населенные пункты</returns>
        public static List<City> GetInfoFromIndex(String indx)
        {
            List<City> result = new List<City>();
            foreach (var item in allCity.Where(c=>c.Index.Equals(indx)))
            {
                result.Add(item);
            }
            return result;
        }
        /// <summary>
        /// Поиск индекса по городу
        /// </summary>
        /// <param name="city">город</param>
        /// <returns>Все варианты город+индекс</returns>
        public static List<City> GetIndexFromCity(String city)
        {
            List<City> result = new List<City>();
            foreach (var item in allCity.Where(c => c.Name.Equals(city)))
            {
                result.Add(item);
            }
            return result;
        }

       
    }
}
