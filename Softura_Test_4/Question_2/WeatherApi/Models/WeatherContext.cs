using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Models
{
    public class WeatherContext:DbContext
    {
        public WeatherContext():base()
        {

        }
        public WeatherContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Weather> Weathers { get; set; }
    }
}
