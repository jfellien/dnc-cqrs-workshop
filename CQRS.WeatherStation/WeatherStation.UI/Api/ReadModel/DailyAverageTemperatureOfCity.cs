namespace WeatherStation.UI.Api.ReadModel
{
  public class DailyAverageTemperatureOfCity
  {
    public string City
    {
      get; set;
    }
    public double Temperature
    {
      get;  set;
    }

    public string Day
    {
      get; set;
    }
  }
}