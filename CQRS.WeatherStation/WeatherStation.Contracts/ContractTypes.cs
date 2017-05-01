using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.Contracts
{
  public class ContractTypes
  {
    public static Type ResolveByName(string typeName)
    {
      var type = Type.GetType(typeName);

      return type;
    }
  }
}
