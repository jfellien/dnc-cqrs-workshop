using Fluent_CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.Contracts.Commands
{
  public class RecordTemperature : IAmACommandMessage
  {
    public string Id
    {
      get; set;
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
