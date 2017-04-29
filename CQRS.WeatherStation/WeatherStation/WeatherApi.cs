using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Jil;
using System.Net;
using System.Configuration;
using WeatherStation.ReadModel;

namespace WeatherStation
{
  public class WeatherApi
  {
    private Cities _cities;
    private DailyAverageTemperatures _dailyAverageTemperatures;

    public WeatherApi()
    {
      _cities = new Cities();
      _dailyAverageTemperatures = new DailyAverageTemperatures();
    }
    public IReadOnlyList<string> GermanCities
    {
      get {
        return _cities.FromGermany();
      }
    }

    public IReadOnlyList<DailyAverageTemperature> GermansDailyAverageTemperatures
    {
      get {
        return _dailyAverageTemperatures.OfGermany().OrderBy(temp => temp.City).ToList();
      }
    }
  }
}
