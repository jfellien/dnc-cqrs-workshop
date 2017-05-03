using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherStation.UI.Api.Contracts;
using WeatherStation.UI.Api.Contracts.Commands;
using WeatherStation.UI.Api.ReadModel;

namespace WeatherStation.UI
{
  public partial class Form1 : Form
  {
    private Func<RecordTemperature, CommandResponse> _handleRecording;

    private string _stationId = ConfigurationManager.AppSettings["StationId"];

    public Form1()
    {
      InitializeComponent();
    }

    public void SetCities(IReadOnlyList<string> cities)
    {
        this.cities.DataSource = cities;
    }

    internal void OnTemperatureMeasured(Func<RecordTemperature, CommandResponse> handle)
    {
      _handleRecording = handle;
    }

    private void save_Click(object sender, EventArgs e)
    {
      var selectedCity = cities.Text;

      double temperature = 0;

      if (Double.TryParse(temperatures.Text, out temperature)) {
        var response = _handleRecording(new RecordTemperature(_stationId) {
          City = selectedCity,
          Temperature = temperature,
          TimeStamp = DateTime.UtcNow
        });

        if (response.Status == CommandResponseStatus.Failure)
          ShowStatusError(response.Message);

        if (response.Status == CommandResponseStatus.Success)
          ShowStatusMessage(response.Message);
      }
      else {
        ShowStatusError("Diese Temperatur ist ungültig");
      }
    }

    internal void RefreshAverageTemperatures(IReadOnlyList<DailyAverageTemperatureOfCity> averageTemperatures)
    {
      this.averageTemperatures.DataSource = averageTemperatures;
    }

    private void ShowStatusMessage(string message)
    {
      statusLabel.ForeColor = SystemColors.ControlText;
      statusLabel.Text = message;
    }
    private void ShowStatusError(string message)
    {
      statusLabel.ForeColor = Color.Red;
      statusLabel.Text = message;
    }
  }
}
