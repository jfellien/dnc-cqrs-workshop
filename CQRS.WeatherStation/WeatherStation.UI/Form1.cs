using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherStation.Contracts;
using WeatherStation.Contracts.Commands;
using WeatherStation.ReadModel;

namespace WeatherStation.UI
{
  public partial class Form1 : Form, IAmTheWeatherStationUI
  {
    private Action<string, double, DateTime> RecordTemperatureValue;

    public Form1()
    {
      InitializeComponent();
    }

    public void SetCities(IReadOnlyList<string> cities)
    {
        this.cities.DataSource = cities;
    }

    public void SetDailyAverageTemperatures(IReadOnlyList<DailyAverageTemperature> dailyAverageTemperatures)
    {
      this.dailyAverageTemperatures.DataSource = dailyAverageTemperatures;
    }

    public void OnRecordTemperature(Action<string, double, DateTime> recordTemperature)
    {
      RecordTemperatureValue = recordTemperature;
    }

    public void ShowFault(string faultMessage)
    {
      statusLabel.ForeColor = Color.Red;
      statusLabel.Text = faultMessage;
    }

    private void save_Click(object sender, EventArgs e)
    {
      var selectedCity = cities.Text;
      double enteredTemperature;

      if (Double.TryParse(temperatures.Text, out enteredTemperature)) {
        var recordedDateTimeAtStation = DateTime.UtcNow;

        statusLabel.ForeColor = SystemColors.ControlText;
        statusLabel.Text = "Temperatur wird erfasst...";

        RecordTemperatureValue(selectedCity, enteredTemperature, recordedDateTimeAtStation);
      }
      else {
        ShowFault("Die Temperatur enthält ein falsches Zahlenformt");
      }
    }
  }
}
