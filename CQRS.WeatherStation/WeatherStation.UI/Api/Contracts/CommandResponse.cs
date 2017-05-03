using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation.UI.Api.Contracts
{
  public enum CommandResponseStatus
  {
    Failure = 0,
    Success = 1
  }

  public abstract class CommandResponse
  {
    public CommandResponse(CommandResponseStatus status, string message)
    {
      Status = status;
      Message = message;
    }
    public CommandResponseStatus Status
    {
      get; private set;
    }

    public string Message
    {
      get; private set;
    }
  }

  public class SuccessResponse : CommandResponse
  {
    public SuccessResponse(string message) : base(CommandResponseStatus.Success, message)
    {

    }
  }

  public class FailureResponse : CommandResponse
  {
    public FailureResponse(string message) : base(CommandResponseStatus.Failure, message)
    {

    }
  }
}
