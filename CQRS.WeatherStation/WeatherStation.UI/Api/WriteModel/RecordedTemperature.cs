using System;

namespace WeatherStation.UI.Api.WriteModel
{
  public class RecordedTemperature
  {
    public string City
    {
      get; set;
    }
    public double Temperature
    {
      get; set;
    }

    public DateTime TimeStamp
    {
      get; set;
    }
  }
}