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
        public List<Country> _countries = new List<Country>();
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

        public CountryRepository()
        {
            _countries = GetCountriesFromDb();
        }

        public void SaveAllMethod(Country country)
        {
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Countries_Countries (Name, Aplha3Code, Capital, Region, Subregion, Population, LatLng, Area, Demonym, TimeZone, Flag) VALUES ('" + country.name + "' , '" + country.alpha3Code + "' , '" + country.capital + "' , '" + country.region + "', '" + country.subregion + "', '" + country.population + "', '" + country.latlng + "' , '" + country.area + "' , '" + country.demonym + "' , '" + country.timeZone + "', '" + country.flag + "')";
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
                            latlng = (string)reader["LatLng"],
                            area = (float)reader["Area"],
                            demonym = (string)reader["Demonym"],
                            timeZone = (string)reader["TimeZone"],
                            flag = (string)reader["Flag"]
                        });
                    }
                }
            }
            return countries;
        }

        public Country GetCountry()
        {
            
        }

        public void EditCountry(Country country)
        {
            using (DbConnection connection = new SqlConnection(connectionString))
            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = "UPDATE Countries_Countries SET Name = '" + country.name + "', Alpha3Code = '" + country.alpha3Code + "', Capital = '" + country.capital + "' Region = " + country.region + "' Subregion = " + country.subregion + "' Population = " + country.population + "'LatLng = " + country.latlng + "' Area = " + country.area + "'Demonym = " + country.demonym + "' TimeZone = " + country.timeZone + "' Flag = " + country.flag + "'";
                connection.Open();
                using (DbDataReader oReader = command.ExecuteReader())
                {

                }
            }
        }
    }
}
