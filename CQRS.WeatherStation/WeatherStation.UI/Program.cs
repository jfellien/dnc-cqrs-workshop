using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherStation.UI.Api;
using WeatherStation.UI.Api.Projections;
using WeatherStation.UI.Api.ReadModel;
using WeatherStation.UI.Api.WriteModel;

namespace WeatherStation.UI
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var weatherStation = new Form1();

      var cities = new Cities(); // Repository
      var temperatures = new Temperatures(); // Repository
      var averageTemperatures = new AverageTemperatures(); // Repository

      var projections = new WeatherStationProjections(averageTemperatures);

      var temperatureReorder = new TemperatureRecorder(temperatures, projections); // Aggregate
      var weatherApi = new WeatherApi(temperatureReorder, cities, averageTemperatures); //CommandHandler und ReadModel API

      weatherStation.SetCities(weatherApi.Cities);
      weatherStation.OnTemperatureMeasured(weatherApi.Handle);

      weatherApi.OnAverageTemperatureChanged(weatherStation.RefreshAverageTemperatures);

      Application.Run(weatherStation);
    }
  }
}
