using Fluent_CQRS;
using Jil;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WeatherStation.Contracts;

namespace WeatherStation.Infrastructure
{
  class AzureEventStore : IStoreAndRetrieveEvents
  {
    string API_URI = ConfigurationManager.AppSettings["WeatherStationEventStoreUri"];
    string API_KEY = ConfigurationManager.AppSettings["WeatherStationEventStoreApiKey"];

    private RestClient _httpClient;

    public AzureEventStore()
    {
      _httpClient = new RestClient(API_URI);
    }

    public void StoreFor<TAggregate>(string aggregateId, IAmAnEventMessage eventMessage) where TAggregate : Aggregate
    {
      var request = new RestRequest("api/v1/event", Method.POST);
      request.AddHeader("x-functions-key", API_KEY);

      var serializedEvent = JSON.Serialize(eventMessage as object);

      request.AddJsonBody(new EventBag {
        EventId = Guid.NewGuid().ToString(),
        AggregateId = aggregateId,
        EventTimeStamp = DateTime.UtcNow,
        TypeOfAggregate = typeof(TAggregate).ToString(),
        TypeOfEvent = eventMessage.GetType().ToString(),
        Event = serializedEvent
      });

      var response = _httpClient.Execute(request);

      if (response.StatusCode != System.Net.HttpStatusCode.OK)
        throw new Exception("Nicht gespeichert");
    }

    public IEnumerable<IAmAnEventMessage> RetrieveFor(string aggregateId)
    {
      var request = new RestRequest($"api/v1/events/{aggregateId}", Method.GET);
      request.AddHeader("x-functions-key", API_KEY);

      var response = _httpClient.Execute<List<EventBag>>(request);
      
      return response.Data.Select(eventBag => {
        var eventType = ContractTypes.ResolveByName(eventBag.TypeOfEvent);

        var @event = JSON.Deserialize(eventBag.Event, eventType) as IAmAnEventMessage;
        return @event;

      });
    }

    public IEnumerable<IAmAnEventMessage> RetrieveFor<TAggregate>(string aggregateId) where TAggregate : Aggregate
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IAmAnEventMessage> RetrieveFor<TAggregate>() where TAggregate : Aggregate
    {
      throw new NotImplementedException();
    }
  }

  class EventBag
  {
    public string EventId
    {
      get; set;
    }
    public string AggregateId
    {
      get; set;
    }
    public string TypeOfAggregate
    {
      get; set;
    }

    public string TypeOfEvent
    {
      get; set;
    }

    public DateTime EventTimeStamp
    {
      get; set;
    }
    public string Event
    {
      get; set;
    }
  }
}
