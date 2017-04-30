using System.Collections.Generic;
using WeatherStation.ReadModel;

namespace WeatherStation.UI
{
  internal interface IAmTheWeatherStationUI
  {
    void SetCities(IReadOnlyList<string> cities);
    void SetDailyAverageTemperatures(IReadOnlyList<DailyAverageTemperature> dailyAverageTemperatures);
  }
}