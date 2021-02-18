using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace kosis
{
    class work
    {
        public void getWork()
        {
            string url = "https://kosis.kr/openapi/statisticsData.do?method=getList&apiKey=NzNlYmQxY2E3NjdlOWEwMTdkOTZkNDhjMDQ4NGU2MTA=&format=json&jsonVD=Y&userStatsId=yhpark/101/DT_2BR21/2/1/20201204104556&prdSe=Y&startPrdDe=2016&endPrdDe=2016";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                string json = wc.DownloadString(url);

                JArray ja = JArray.Parse(json);

                for (int i = 0; i < ja.Count; i++)
                {
                    kosis_work model = new kosis_work();
                    model.PRD_DE = ja[i].SelectToken("PRD_DE").ToString();
                    model.C1_NM = ja[i].SelectToken("C1_NM").ToString();
                    model.C1_NM_ENG = ja[i].SelectToken("C1_NM_ENG").ToString();
                    model.C2_NM = ja[i].SelectToken("C2_NM").ToString();
                    model.C2_NM_ENG = ja[i].SelectToken("C2_NM_ENG").ToString();
                    model.C3_NM = ja[i].SelectToken("C3_NM").ToString();
                    model.C4_NM = ja[i].SelectToken("C4_NM").ToString();
                    model.ITM_NM = ja[i].SelectToken("ITM_NM").ToString();
                    model.UNIT_NM = ja[i].SelectToken("UNIT_NM").ToString();
                    model.DT = ja[i].SelectToken("DT").ToString();

                    StringBuilder sb = new StringBuilder();
                    sb.Append(" insert into kosis_work values(");
                    sb.Append(" '" + model.PRD_DE.Replace("'", "") + "',");
                    sb.Append(" '" + model.C1_NM.Replace("'", "") + "',");
                    sb.Append(" '" + model.C1_NM_ENG.Replace("'", "") + "',");
                    sb.Append(" '" + model.C2_NM.Replace("'", "") + "',");
                    sb.Append(" '" + model.C2_NM_ENG.Replace("'", "") + "',");
                    sb.Append(" '" + model.C3_NM.Replace("'", "") + "',");
                    sb.Append(" '" + model.C4_NM.Replace("'", "") + "',");
                    sb.Append(" '" + model.ITM_NM.Replace("'", "") + "',");
                    sb.Append(" '" + model.UNIT_NM.Replace("'", "") + "',");
                    sb.Append(" '" + model.DT.Replace("'", "") + "')");

                    Program.insert(sb.ToString());
                }
            }
        }
    }

    internal class kosis_work
    {
        public string PRD_DE { get; set; }
        public string C1_NM { get; set; }
        public string C1_NM_ENG { get; set; }
        public string C2_NM { get; set; }
        public string C2_NM_ENG { get; set; }
        public string C3_NM { get; set; }
        public string C4_NM { get; set; }
        public string ITM_NM { get; set; }
        public string UNIT_NM { get; set; }
        public string DT { get; set; }
    }
}
