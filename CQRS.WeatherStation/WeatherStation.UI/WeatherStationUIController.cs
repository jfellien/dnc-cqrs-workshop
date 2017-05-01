using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherStation.Contracts.Commands;

namespace WeatherStation.UI
{
  class WeatherStationUIController
  {
    WeatherApi _weatherApi;
    IAmTheWeatherStationUI _weatherStationUI;

    public static Form InitUIWith(IAmTheWeatherStationUI weatherStationUI, WeatherApi weatherApi)
    {
      return new WeatherStationUIController(weatherStationUI, weatherApi).SetupUI();
    }

    protected WeatherStationUIController(IAmTheWeatherStationUI weatherStationUI, WeatherApi weatherApi)
    {
      _weatherStationUI = weatherStationUI;
      _weatherApi = weatherApi;
    }

    private Form SetupUI()
    {
      _weatherStationUI.SetCities(_weatherApi.GermanCities);
      _weatherStationUI.SetDailyAverageTemperatures(_weatherApi.GermansDailyAverageTemperatures);
      _weatherStationUI.OnRecordTemperature(RecordTemperature);
      _weatherApi.OnFaults(_weatherStationUI.ShowFault);

      return _weatherStationUI as Form;
    }

    void RecordTemperature(string city, double temperature, DateTime timestamp)
    {
      _weatherApi.RecordTemperature(new RecordTemperature {
        City = city,
        Temperature = temperature,
        TimeStamp = timestamp
      });

      _weatherStationUI.SetDailyAverageTemperatures(_weatherApi.GermansDailyAverageTemperatures);

    }
  }
}
