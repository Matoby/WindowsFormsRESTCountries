using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Country
    {
        public string name { get; set; }
        public string alpha3Code { get; set; }
        public string capital { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public int population { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public float area { get; set; }
        public string demonym { get; set; }
        public string timeZone { get; set; }
        public string flag { get; set; }
    }
}
