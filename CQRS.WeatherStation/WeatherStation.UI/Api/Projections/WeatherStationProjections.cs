using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherStation.UI.Api.ReadModel;
using WeatherStation.UI.Api.WriteModel;

namespace WeatherStation.UI.Api.Projections
{
  class WeatherStationProjections
  {
    private AverageTemperatures _averageTemperatures;

    public WeatherStationProjections(AverageTemperatures averageTemperatures)
    {
      _averageTemperatures = averageTemperatures;
    }

    public void Handle(RecordedTemperature recordedTemperature)
    {
      var dailyAverageTemperatures = _averageTemperatures.OfCity(recordedTemperature.City);
      var recordingDay = recordedTemperature.TimeStamp.ToString("yyyy-MM-dd");

      var lastAverageTempertureOfDay = dailyAverageTemperatures.Any()
        ? dailyAverageTemperatures.Single(t => t.Day == recordingDay)
        : null;

      var nextAverageTemperatureOfDay = new DailyAverageTemperatureOfCity {
        City = recordedTemperature.City,
        Day = recordingDay
      };

      if (lastAverageTempertureOfDay != null) {
        nextAverageTemperatureOfDay.Temperature = 
          (lastAverageTempertureOfDay.Temperature + recordedTemperature.Temperature) / 2;
      }
      else {
        nextAverageTemperatureOfDay.Temperature = recordedTemperature.Temperature;
      }

      _averageTemperatures.Store(nextAverageTemperatureOfDay);
    }
  }
}
