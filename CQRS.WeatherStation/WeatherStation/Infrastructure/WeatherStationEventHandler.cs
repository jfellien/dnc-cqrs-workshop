using Fluent_CQRS;
using Fluent_CQRS.Extensions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherStation.Contracts.Events;

namespace WeatherStation.Infrastructure
{
  class WeatherStationEventHandler : IHandleEvents
  {
    string API_URI = ConfigurationManager.AppSettings["WeatherStationProjectionsUri"];
    string API_KEY = ConfigurationManager.AppSettings["WeatherStationProjectionsApiKey"];

    private RestClient _httpClient;

    public WeatherStationEventHandler()
    {
      _httpClient = new RestClient(API_URI);
    }

    public void Receive(IEnumerable<IAmAnEventMessage> events)
    {
      events.ToList().ForEach(message => message.HandleMeWith(this));
    }

    public void Handle(TemperatureRecorded @event)
    {
      var request = new RestRequest("api/v1/handle-temperature-recorded", Method.POST);
      request.AddHeader("x-functions-key", API_KEY);

      request.AddJsonBody(new {
        City = @event.City,
        Temperature = @event.Temperature,
        Date = @event.TimeStamp.Date.ToString("yyyy-MM-dd")
      });

      var response = _httpClient.Execute(request);

      if (response.StatusCode != System.Net.HttpStatusCode.OK)
        throw new ApplicationException("Error while handle Event");
    }
  }
}
