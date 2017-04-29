using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Jil;
using System.Net;
using System.Configuration;

namespace WeatherStation.UI.Api
{
  class WeatherApi
  {
    string CITIES_URL = ConfigurationManager.AppSettings["CitiesUri"];
    string CITIES_API_KEY = ConfigurationManager.AppSettings["CitiesApiKey"];

    private RestClient _httpClient;
    private List<string> _cities;

    public WeatherApi()
    {
      _httpClient = new RestClient();
    }
    public IReadOnlyList<string> Cities
    {
      get {

        if (_cities == null) {
          _httpClient.BaseUrl = new Uri(CITIES_URL);
          var request = new RestRequest("api/v1/cities", Method.GET);
          request.AddHeader("x-functions-key", CITIES_API_KEY);

          var response = _httpClient.Execute(request);

          if (response.StatusCode == HttpStatusCode.OK) {
            _cities = JSON.Deserialize<List<string>>(response.Content);
          }
          else {
            _cities = new List<string>();
          }
        }

        return _cities;
      }
    }
  }
}
