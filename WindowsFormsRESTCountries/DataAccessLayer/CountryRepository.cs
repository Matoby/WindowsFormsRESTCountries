using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace DataAccessLayer
{
    public class CountryRepository
    {
        private List<Country> _countries = new List<Country>();
        string url = "https://restcountries.eu/rest/v2/all";
        
        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(),
           enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }

        public CountryRepository()
        {
            string json = CallRestMethod(url);

            JArray jsonObject = JArray.Parse(json);

            foreach (JObject item in jsonObject)
            {
                _countries.Add(new Country
                {
                    name = (string)item["name"],
                    alpha3Code = (string)item["alpha3Code"],
                    capital = (string)item["capital"],
                    region = (string)item["region"],
                    subregion = (string)item["subregion"],
                    population = (int)item["population"],
                    latlng = (string)item["latlng"].ToString(),
                    area = item["area"].Type == JTokenType.Null ? 0 : (float)item["area"],
                    demonym = (string)item["demonym"],
                    timeZone = (string)item["timezones"].ToString(),
                    flag = (string)item["flag"]
                });
            }
        }

        public List<Country> ImportCountries()
        {
            return _countries;
        }
    }
}
