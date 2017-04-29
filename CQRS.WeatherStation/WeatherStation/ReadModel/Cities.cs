using Jil;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.ReadModel
{
  class Cities
  {
    string CITIES_URL = ConfigurationManager.AppSettings["WeatherStationUrl"];
    string CITIES_API_KEY = ConfigurationManager.AppSettings["WeatherStationApiKey"];

    private RestClient _httpClient;

    public Cities()
    {
      _httpClient = new RestClient(CITIES_URL);
    }

    public IReadOnlyList<string> FromGermany()
    {
      IReadOnlyList<string> cities;

      var request = new RestRequest("api/v1/cities/Germany", Method.GET);
      request.AddHeader("x-functions-key", CITIES_API_KEY);

      var response = _httpClient.Execute(request);

      if (response.StatusCode == HttpStatusCode.OK) {
        cities = JSON.Deserialize<List<string>>(response.Content);
      }
      else {
        cities = new List<string>();
      }

      return cities;
    }
  }
}
