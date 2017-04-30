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

      var blankStationUI = new Form1();
      var weatherApi = new WeatherApi();

      var weatherStation = WeatherStationUIController.InitUIWith(blankStationUI, weatherApi);

      Application.Run(weatherStation);
    }
  }
}
