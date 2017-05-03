using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.UI.Api.Contracts.Commands
{
  public class RecordTemperature
  {
    public RecordTemperature(string stationId)
    {
      StationId = stationId;
    }
    public string StationId
    {
      get; private set;
    }
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
