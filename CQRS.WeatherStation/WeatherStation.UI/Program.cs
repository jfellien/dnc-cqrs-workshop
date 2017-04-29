using System;
using System.Windows.Forms;

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
      var weatherApi = new WeatherApi();

      weatherStation.SetCities(weatherApi.GermanCities);
      weatherStation.SetDailyAverageTemperatures(weatherApi.GermansDailyAverageTemperatures);

      Application.Run(weatherStation);
    }
  }
}
