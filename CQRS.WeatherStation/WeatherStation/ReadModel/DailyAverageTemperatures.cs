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
  class DailyAverageTemperatures
  {

    string API_URI = ConfigurationManager.AppSettings["WeatherStationReadModelUri"];
    string API_KEY = ConfigurationManager.AppSettings["WeatherStationReadModelApiKey"];

    private RestClient _httpClient;

    public DailyAverageTemperatures()
    {
      _httpClient = new RestClient(API_URI);
    }

    public IReadOnlyList<DailyAverageTemperature> OfGermany()
    {
      IReadOnlyList<DailyAverageTemperature> temperatures;

      var request = new RestRequest("api/v1/germans-daily-average-temperature", Method.GET);
      request.AddHeader("x-functions-key", API_KEY);

      var response = _httpClient.Execute(request);

      if (response.StatusCode == HttpStatusCode.OK) {
        temperatures = JSON.Deserialize<List<DailyAverageTemperature>>(response.Content);
      }
      else {
        temperatures = new List<DailyAverageTemperature>();
      }

      return temperatures;
    }
  }
}
