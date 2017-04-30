using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

      return _weatherStationUI as Form;
    }
  }
}
