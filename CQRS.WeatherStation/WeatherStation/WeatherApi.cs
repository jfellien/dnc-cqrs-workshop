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

    public WeatherApi()
    {
      _cities = new Cities();
    }
    public IReadOnlyList<string> GermanCities
    {
      get {
        return _cities.FromGermany();
      }
    }
  }
}
