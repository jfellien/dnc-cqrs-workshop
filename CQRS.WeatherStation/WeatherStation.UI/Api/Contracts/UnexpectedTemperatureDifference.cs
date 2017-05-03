using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.UI.Api.Contracts
{
  public class UnexpectedTemperatureDifference : Exception
  {
    public UnexpectedTemperatureDifference() : base("Unerwartete Temperaturdifferenz")
    {

    }
  }
}
