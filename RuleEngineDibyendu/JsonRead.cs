using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngineDibyendu
{
    public static class JsonRead
    {
        static string filepath = "../../raw_data.json";
        public static List<CustomData> ReadJsonData()
        {
            List<CustomData> lstRawData = null;
            string result = string.Empty;
            using (StreamReader r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
                var myDetails = JsonConvert.DeserializeObject<object>(json);
                lstRawData = JsonConvert.DeserializeObject<List<CustomData>>(json);
            }

            return lstRawData;
        }


    }
}
