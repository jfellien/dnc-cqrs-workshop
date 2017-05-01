using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.Contracts
{
  public abstract class RecordingResult
  {
    private ResultStatus failure;

    public RecordingResult(string message, ResultStatus failure)
    {
      Message = message;
      this.failure = failure;
    }

    public ResultStatus Status
    {
      get; private set;
    }

    public string Message
    {
      get; private set;
    }
  }

  public class RecordingResultFailure : RecordingResult
  {
    public RecordingResultFailure(string message) : base(message, ResultStatus.Failure)
    {

    }
  }

  public class RecordingResultSuccess : RecordingResult
  {
    public RecordingResultSuccess(string message) : base(message, ResultStatus.Success)
    {

    }
  }
}
