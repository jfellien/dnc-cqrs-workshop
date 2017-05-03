using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.UI.Api.WriteModel
{
  class Temperatures
  {
    /// <summary>
    /// Temperaturen zur Station laden
    /// </summary>
    /// <param name="stationId"></param>
    /// <returns></returns>
    public IReadOnlyList<RecordedTemperature> OfStation(string stationId)
    {
      return new List<RecordedTemperature>();
    }

    /// <summary>
    /// Speichern des neuen Wertes
    /// </summary>
    /// <param name="stationId"></param>
    /// <param name="recordedTemperature"></param>
    public void StoreForStation(string stationId, RecordedTemperature recordedTemperature)
    {
    }
  }
}
