using Jil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.ReadModel
{
  public class DailyAverageTemperature
  {
    [JilDirective(Name = "city")]
    public string City
    {
      get; set;
    }
    
    [JilDirective(Name = "date")]
    public string Date
    {
      get; set;
    }

    [JilDirective(Name = "average_temperature")]
    public double Temperature
    {
      get; set;
    }
  }
}
