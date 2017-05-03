using Jil;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.UI.Api.ReadModel
{
  class Cities
  {
    string CITIES_URL = ConfigurationManager.AppSettings["WeatherStationReadModelUri"];
    string CITIES_API_KEY = ConfigurationManager.AppSettings["WeatherStationReadModelApiKey"];

    private RestClient _httpClient;

    public Cities()
    {
      _httpClient = new RestClient(CITIES_URL);
    }

    public IReadOnlyList<string> All()
    {
      _httpClient.BaseUrl = new Uri(CITIES_URL);
      var request = new RestRequest("api/v1/cities", Method.GET);
      request.AddHeader("x-functions-key", CITIES_API_KEY);

      var response = _httpClient.Execute(request);

      return response.StatusCode == HttpStatusCode.OK
        ? JSON.Deserialize<List<string>>(response.Content) 
        : new List<string>() { "Berlin", "Hamburg", "Köln" };
    }
  }
}
