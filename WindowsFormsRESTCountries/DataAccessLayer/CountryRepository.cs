using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Data.Common;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace DataAccessLayer
{
    public class CountryRepository
    {
        public List<Country> _countries = new List<Country>();
        string url = "https://restcountries.eu/rest/v2/all";
        string connectionString = "Data Source=193.198.57.183; Initial Catalog = DotNet;User ID = vjezbe; Password = vjezbe";

        /*public CountryRepository()
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
                    lat = item["latlng"].Type == JTokenType.Null ? 0 : (float)item["latlng"][0],
                    //lng = item["latlng"].Type == JTokenType.None ? 0 : (float)item["latlng"][1],
                    area = item["area"].Type == JTokenType.Null ? 0 : (float)item["area"],
                    demonym = (string)item["demonym"],
                    //timeZone = (string)item["timezones"][0],
                    flag = (string)item["flag"]
                });
            }
            //Console.WriteLine(_countries.Count);
        }*/

        public List<Country> GetCountries()
        {
            string json = CallRestMethod(url);
            JArray jsonObject = JArray.Parse(json);

            foreach(JObject item in json)
            {
                string name = (string)item.GetValue("name");
                string alpha3Code = (string)item.GetValue("aplha3Code");
                string capital = (string)item.GetValue("capital");
                string region = (string)item.GetValue("region");
                string subregion = (string)item.GetValue("subregion");
                var latlng = item["latlng"].ToList();
                float lat = 0;
                float lng = 0;
                for(int i = 0; i < latlng.Count; i++)
                {
                    if(i == 0)
                    {
                        lat = (float)latlng[i];
                    }
                    if(i == 1)
                    {
                        lng = (float)latlng[i];
                    }
                }
            }

            return _countries;
        }

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

        public void SaveAllMethod(Country country)
        {
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                var query = "INSERT INTO Countries_Countries (Name, Aplha3Code, Capital, Region, Subregion, Population, Lat, Lng, Area, Demonym, TimeZone, Flag) VALUES ('" + country.name + "' , '" + country.alpha3Code + "' , '" + country.capital + "' , '" + country.region + "', '" + country.subregion + "', '" + country.population + "', '" + country.lat + "' , '" + country.lng + "', '" + country.area + "' , '" + country.demonym + "' , '" + country.timeZone + "', '" + country.flag + "')";
                Console.WriteLine(query);
                command.CommandText = query;
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                }
            }
        }

        public List<Country> GetCountriesFromDb()
        {
            var countries = new List<Country>();
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Countries_Countries]";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        countries.Add(new Country()
                        {
                            name = (string)reader["Name"],
                            alpha3Code = (string)reader["Alpha3Code"],
                            capital = (string)reader["Capital"],
                            region = (string)reader["Region"],
                            subregion = (string)reader["Subregion"],
                            population = (int)reader["Population"],
                            lat = (float)reader["Lat"],
                            lng = (float)reader["Lng"],
                            area = (float)reader["Area"],
                            demonym = (string)reader["Demonym"],
                            timeZone = (string)reader["Time Zone"],
                            flag = (string)reader["Flag"]
                        });
                    }
                }
            }
            return countries;
        }

        public void EditCountry(Country country)
        {
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Countries_Countries SET Name = '" + country.name + "', Alpha3Code = '" + country.alpha3Code + "', Capital = '" + country.capital + "' Region = " + country.region + "' Subregion = " + country.subregion + "' Population = " + country.population + "'Lat = " + country.lat + "' Lng = " +country.lng +  "' Area = " + country.area + "'Demonym = " + country.demonym + "' TimeZone = " + country.timeZone + "' Flag = " + country.flag + "'";
                connection.Open();
                using (DbDataReader oReader = command.ExecuteReader())
                {

                }
            }
        }
    }
}
