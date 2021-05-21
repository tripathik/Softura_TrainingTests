using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherClient.Models
{
    public partial class Weather
    {
       
        public int wid { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public float HighTemp { get; set; }
        public float LowTemp { get; set; }
        public string ForCast { get; set; }

    }
}
