using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherStation.UI.Api;

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

      weatherStation.SetCities(weatherApi.Cities);

      Application.Run(weatherStation);
    }
  }
}
