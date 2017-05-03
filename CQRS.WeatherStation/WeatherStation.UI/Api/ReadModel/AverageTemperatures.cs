using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.UI.Api.ReadModel
{
  class AverageTemperatures
  {
    private List<DailyAverageTemperatureOfCity> _all;

    public AverageTemperatures()
    {
      _all = new List<DailyAverageTemperatureOfCity>();
    }
    public void Store(DailyAverageTemperatureOfCity dailyAverageTemperature)
    {
      if (_all.Any(x => x.City == dailyAverageTemperature.City && x.Day == dailyAverageTemperature.Day)) {
        _all.Single(x => x.City == dailyAverageTemperature.City && x.Day == dailyAverageTemperature.Day)
          .Temperature = dailyAverageTemperature.Temperature;
      }
      else {
        _all.Add(dailyAverageTemperature);
      }
    }
    public IReadOnlyList<DailyAverageTemperatureOfCity> OfCity(string city)
    {
      return _all.Where( x => x.City == city).ToList();
    }

    internal IReadOnlyList<DailyAverageTemperatureOfCity> All()
    {
      return _all;
    }
  }
}
