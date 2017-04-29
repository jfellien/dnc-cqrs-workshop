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

    string AVERAGE_TEMPERATURES_URL = ConfigurationManager.AppSettings["WeatherStationUrl"];
    string AVERAGE_TEMPERATURES_API_KEY = ConfigurationManager.AppSettings["WeatherStationApiKey"];

    private RestClient _httpClient;

    public DailyAverageTemperatures()
    {
      _httpClient = new RestClient(AVERAGE_TEMPERATURES_URL);
    }

    public IReadOnlyList<DailyAverageTemperature> OfGermany()
    {
      IReadOnlyList<DailyAverageTemperature> temperatures;

      var request = new RestRequest("api/v1/germans-daily-average-temperature", Method.GET);
      request.AddHeader("x-functions-key", AVERAGE_TEMPERATURES_API_KEY);

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
