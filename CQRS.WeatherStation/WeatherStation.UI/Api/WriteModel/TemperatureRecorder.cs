using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherStation.UI.Api.Contracts;
using WeatherStation.UI.Api.Projections;

namespace WeatherStation.UI.Api.WriteModel
{
  class TemperatureRecorder
  {
    private Temperatures _temperatures;
    private WeatherStationProjections _projections;
    public TemperatureRecorder(Temperatures temperatures, WeatherStationProjections projections)
    {
      _temperatures = temperatures;
      _projections = projections;
    }
    public void Record(string stationId, string city, double temperature, DateTime timestamp)
    {
      if (_temperatures.OfStation(stationId).Any()) {
      
        var lastTemperature = _temperatures.OfStation(stationId).Last().Temperature;
        var tempDiff = lastTemperature - temperature;

        if (tempDiff > 10 || tempDiff < -10)
          throw new UnexpectedTemperatureDifference();
      }

      var recordedTemperature = new RecordedTemperature {
        City = city,
        Temperature = temperature,
        TimeStamp = timestamp
      };

      _temperatures.StoreForStation(stationId, recordedTemperature);

      _projections.Handle(recordedTemperature);
    }
  }
}
