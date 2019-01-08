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

namespace DataAccessLayer
{
    public class CountryRepository
    {
        private List<Country> _countries = new List<Country>();
        string url = "https://restcountries.eu/rest/v2/all";
        string connectionString = "Data Source=193.198.57.183; Initial Catalog = DotNet;User ID = vjezbe; Password = vjezbe";

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
                command.CommandText = "INSERT INTO Countries_Countries (Name, Aplha3Code, Capital, Region, Subregion, Population, LatLng, Area, Demonym, Flag) VALUES ('" + country.name + "' , '" + country.alpha3Code + "' , '" + country.capital + "' , '" + country.region + "', '" + country.subregion + "', '" + country.population + "', '" + country.latlng + "' , '" + country.area + "' , '" + country.demonym + "' , '" + country.flag + "')";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                }
            }
        }

        public Country GetCountriesFromDb()
        {
            List<Country> countries = new List<Country();
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Countries_Countries]";
                connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        countries.Add(new Country
                        {
                            name = (string)reader["Name"],
                            alpha3Code = (string)reader["Alpha3Code"],
                            capital = (string)reader["Capital"],
                            region = (string)reader["Region"],
                            subregion = (string)reader["Subregion"],
                            population = (int)reader["Population"],
                            latlng = (string)reader["LatLng"],
                            area = (float)reader["Area"],
                            demonym = (string)reader["Demonym"],
                            flag = (string)reader["Flag"]
                        });
                    }
                }
            }
            return countries;
        }


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
                    latlng = (string)item["latlng"].ToString(),
                    area = item["area"].Type == JTokenType.Null ? 0 : (float)item["area"],
                    demonym = (string)item["demonym"],
                    timeZone = (string)item["timezones"].ToString(),
                    flag = (string)item["flag"]
                });
            }
        }*/

        public List<Country> ImportCountries()
        {
            return _countries;
        }


    }
}
