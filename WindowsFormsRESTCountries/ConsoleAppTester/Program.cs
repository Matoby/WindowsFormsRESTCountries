using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace ConsoleAppTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new CountryRepository();
            var countries = repo.GetCountriesFromDb();
            //var countryClass = new Country();
            // repo.SaveAllMethod(countryClass);
            /*var countries = repo.GetCountriesFromDb();
            foreach(var country in countries)
            {
                Console.WriteLine(country.name);
                Console.WriteLine(country.alpha3Code);
                Console.WriteLine(country.capital);
                Console.WriteLine(country.region);
                Console.WriteLine(country.subregion);
                Console.WriteLine(country.population);
                Console.WriteLine(country.latlng);
                Console.WriteLine(country.area);
                Console.WriteLine(country.demonym);
                Console.WriteLine(country.timeZone);
                Console.WriteLine(country.flag);
                Console.WriteLine("\n");
            }*/
            Console.ReadKey();
        }
    }
}
