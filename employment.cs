using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kosis
{
    class employment
    {
        public void getEmployment()
        {
            string url = "https://kosis.kr/openapi/statisticsData.do?method=getList&apiKey=NzNlYmQxY2E3NjdlOWEwMTdkOTZkNDhjMDQ4NGU2MTA=&format=json&jsonVD=Y&userStatsId=yhpark/101/DT_2BR08/2/1/20201204095551&prdSe=Y&startPrdDe=2016&endPrdDe=2016";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string json = wc.DownloadString(url);

                JArray ja = JArray.Parse(json);

                for (int i = 0; i < ja.Count; i++)
                {
                    kosis_employment model = new kosis_employment();
                    model.PRD_DE = ja[i].SelectToken("PRD_DE").ToString();
                    model.C_NM = ja[i].SelectToken("C1_NM").ToString();
                    model.C_NM_ENG = ja[i].SelectToken("C1_NM_ENG").ToString();
                    model.ITM_NM = ja[i].SelectToken("ITM_NM").ToString();
                    model.ITM_NM_ENG = ja[i].SelectToken("ITM_NM_ENG").ToString();
                    model.UNIT_NM = ja[i].SelectToken("UNIT_NM").ToString();
                    model.DT = ja[i].SelectToken("DT").ToString();

                    StringBuilder sb = new StringBuilder();
                    sb.Append(" insert into kosis_employment values(");
                    sb.Append(" '" + model.PRD_DE.Replace("'", "") + "',");
                    sb.Append(" '" + model.C_NM.Replace("'", "") + "',");
                    sb.Append(" '" + model.C_NM_ENG.Replace("'", "") + "',");
                    sb.Append(" '" + model.ITM_NM.Replace("'", "") + "',");
                    sb.Append(" '" + model.ITM_NM_ENG.Replace("'", "") + "',");
                    sb.Append(" '" + model.UNIT_NM.Replace("'", "") + "',");
                    sb.Append(" '" + model.DT.Replace("'", "") + "')");

                    Program.insert(sb.ToString());
                }
            }
        }
    }

    internal class kosis_employment
    {
        public string PRD_DE { get; set; }
        public string C_NM { get; set; }
        public string C_NM_ENG { get; set; }
        public string ITM_NM { get; set; }
        public string ITM_NM_ENG { get; set; }
        public string UNIT_NM { get; set; }
        public string DT { get; set; }
    }
}
