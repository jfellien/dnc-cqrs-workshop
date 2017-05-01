using Fluent_CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherStation.Contracts.Events;
using WeatherStation.Contracts.Faults;

namespace WeatherStation.Domain
{
  class TemperatureRecorder : Aggregate
  {
    public TemperatureRecorder(string id, IEnumerable<IAmAnEventMessage> history) : base(id, history)
    {
    }

    public void Record(string city, double temperature, DateTime timestamp)
    {
      if (MessagesOfType<TemperatureRecorded>().Any()) {
        var lastRecord = MessagesOfType<TemperatureRecorded>().Last();

        if (UnexpectedTempertureDifference(lastRecord.Temperature, temperature))
          throw new UnexpectedTemperatureDifference();
      }

      Changes.Add(new TemperatureRecorded {
        Id = this.Id,
        City = city,
        Temperature = temperature,
        TimeStamp = timestamp
      });
    }

    private bool UnexpectedTempertureDifference(double lastMeasurement, double currentMeasurement)
    {
      var difference = lastMeasurement - currentMeasurement;

      return (difference > 10 || difference < -10);
    }
  }
}
