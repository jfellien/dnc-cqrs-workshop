using Fluent_CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.Contracts.Faults
{
  public class UnexpectedTemperatureDifference : Fault
  {
    public UnexpectedTemperatureDifference() : this("Unerwartete Temperaturdifferenz von +/- 10°C")
    {

    }

    public UnexpectedTemperatureDifference(string message) : base(message)
    {
    }
  }
}
