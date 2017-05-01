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
using WeatherStation.Contracts;
using WeatherStation.Contracts.Commands;
using Fluent_CQRS;
using WeatherStation.Infrastructure;
using WeatherStation.Domain;
using Fluent_CQRS.Extensions;

namespace WeatherStation
{
  public class WeatherApi
  {
    string STATION_ID = ConfigurationManager.AppSettings["StationId"];

    private Aggregates _aggregates;

    private Cities _cities;
    private DailyAverageTemperatures _dailyAverageTemperatures;

    private Action<string> ShowFaultMessage;

    public WeatherApi()
    {
      _cities = new Cities();
      _dailyAverageTemperatures = new DailyAverageTemperatures();
      _aggregates = Aggregates.CreateWith(new AzureEventStore());

      _aggregates.PublishNewStateTo(new WeatherStationEventHandler());
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

    public void RecordTemperature(RecordTemperature command)
    {
      _aggregates
        .Provide <TemperatureRecorder>()
        .With(new AggregateId(STATION_ID))
        .Try(temperatureRecorder => temperatureRecorder.Record(command.City, command.Temperature, command.TimeStamp))
        .CatchFault(fault => Handle(fault))
        .CatchException(exception => Handle(exception));
    }

    public void OnFaults(Action<string> showFaultMessage)
    {
      ShowFaultMessage = showFaultMessage;
    }

    private void Handle(Fault fault)
    {
      ShowFaultMessage(fault.Message);
    }

    private void Handle(Exception exception)
    {
      // Like ShowFaultMessage
    }
  }
}