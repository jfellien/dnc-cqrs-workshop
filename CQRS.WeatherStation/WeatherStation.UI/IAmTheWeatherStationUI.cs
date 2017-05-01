using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherStation.Contracts;
using WeatherStation.Contracts.Commands;
using WeatherStation.ReadModel;

namespace WeatherStation.UI
{
  internal interface IAmTheWeatherStationUI
  {
    void SetCities(IReadOnlyList<string> cities);

    void SetDailyAverageTemperatures(IReadOnlyList<DailyAverageTemperature> dailyAverageTemperatures);

    void OnRecordTemperature(Action<string, double, DateTime> recordTemperature);

    void ShowFault(string faultMessage);
  }
}