using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngineDibyendu
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CustomData> lstRawData = JsonRead.ReadJsonData();

            List<CustomData> lstFinalData = new List<CustomData>();  // This list is for correct data
            List<CustomData> lstWrongData = new List<CustomData>();  // This list is for wrong data
                                                                     // Validate all the data in the list and process---


            lstFinalData = (from obj in lstRawData where ValidateData.Validation(obj) select obj).ToList();  // Fetching correct data in the list

            lstWrongData = (from obj in lstRawData where !ValidateData.Validation(obj) select obj).ToList();  // Fetching wrong data in the list

            Console.WriteLine(" *******************Correct Data******************* {0} ******", lstFinalData.Count);
            foreach (var item in lstFinalData)
            {
                Console.WriteLine("Signal : {0}, Value Type : {1}, Value: {2} ", item.Signal, item.Value_Type, item.Value);
            }
            Console.WriteLine(" *******************Wrong Data*******************{0}********", lstWrongData.Count);
            foreach (var item in lstWrongData)
            {
                Console.WriteLine("Signal : {0}, Value Type : {1}, Value: {2} ", item.Signal, item.Value_Type, item.Value);
            }

            Console.ReadLine();

        }
    }
}
