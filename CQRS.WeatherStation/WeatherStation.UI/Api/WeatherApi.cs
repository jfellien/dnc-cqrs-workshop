using System;
using System.Collections.Generic;
using RestSharp;
using Jil;
using System.Net;
using System.Configuration;
using WeatherStation.UI.Api.Contracts;
using WeatherStation.UI.Api.Contracts.Commands;
using WeatherStation.UI.Api.WriteModel;
using WeatherStation.UI.Api.ReadModel;

namespace WeatherStation.UI.Api
{
  class WeatherApi
  {
    
    private Cities _cities;
    private TemperatureRecorder _temperatureRecorder;
    private AverageTemperatures _averageTemperatures;
    private Action<IReadOnlyList<DailyAverageTemperatureOfCity>> _refreshAverageTemperatures;

    public WeatherApi(TemperatureRecorder temperatureRecorder, Cities cities, AverageTemperatures averageTemperatures)
    {
      _temperatureRecorder = temperatureRecorder;
      _cities = cities;
      _averageTemperatures = averageTemperatures;

    }
    public IReadOnlyList<string> Cities
    {
      get {
        return _cities.All();
      }
    }

    //=========================================================
    // Variationen des "Command Handlers"
    //=========================================================

    /// <summary>
    /// Variante 1: Handle Methode mit Rückgabe
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public CommandResponse Handle(RecordTemperature command)
    {
      try {
        _temperatureRecorder.Record(command.StationId, command.City, command.Temperature, command.TimeStamp);
      }
      catch (UnexpectedTemperatureDifference ex) {
        return new FailureResponse(ex.Message);
      }

      _refreshAverageTemperatures(_averageTemperatures.All());

      return new SuccessResponse("Temperatur wurde erfasst");
    }

    /// <summary>
    /// Variante 2: 
    /// </summary>
    /// <returns></returns>
    public object Methode()
    {
      return null;
    }

    internal void OnAverageTemperatureChanged(Action<IReadOnlyList<DailyAverageTemperatureOfCity>> refreshAverageTemperatures)
    {
      _refreshAverageTemperatures = refreshAverageTemperatures;
    }
  }
}
