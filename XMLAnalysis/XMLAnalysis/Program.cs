using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using XML_Analysis.Models;


namespace XMLAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            var Gov_Cases = findOpenData();
            ShowOpenData(Gov_Cases);
            Console.ReadKey();
        }

        static List<OpenData> findOpenData()
        {
            List<OpenData> result = new List<OpenData>();

            var xml = XElement.Load(@"C:\Users\User\source\repos\paul19980606\20181005xmlAnalysis\XMLAnalysis\Gov_Case.xml");

            var Gov_Cases = xml.Descendants("Gov_Case").ToList();

            for (var i = 0; i < Gov_Cases.Count; i++)
            {
                var Gov_Case_data = Gov_Cases[i];
                OpenData item = new OpenData();

                item.年度 = getValue(Gov_Case_data, "年度");
                item.案名 = getValue(Gov_Case_data, "案名");
                item.縣市 = getValue(Gov_Case_data, "縣市");
                result.Add(item);
            };


            return result;
        }

        private static string getValue(XElement Gov_Case_data, string propertyName)
        {
            return Gov_Case_data.Element(propertyName)?.Value?.Trim();
        }

        public static void ShowOpenData(List<OpenData> Gov_Cases)
        {
            Console.WriteLine(string.Format("共收到{0}筆的資料 ", Gov_Cases.Count));
            Gov_Cases.GroupBy(Gov_Case => Gov_Case.縣市).ToList()
                .ForEach(group =>
                {
                    var key = group.Key;
                    var groupDatas = group.ToList();
                    var message = $"縣市:{key},共有{groupDatas.Count()}筆資料";
                    Console.WriteLine(message);
                }
                );


        }

    }
}
