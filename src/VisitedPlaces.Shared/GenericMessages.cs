using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace VisitedPlaces.Shared;

public static partial class GenericMessages
{
    #region Trace messages 0001 - 1000
    [LoggerMessage(
       EventId = 0x0001,
       EventName = nameof(GenericMessages),
       Level = LogLevel.Trace,
       Message = "ENTRY:{caller}")]
    static partial void trcEntryMessage(ILogger logger, string? caller);
    public static void TrcEntryMessage(this ILogger logger, [CallerMemberName] string? caller = null) { trcEntryMessage(logger, caller); }
    #endregion
    #region Debug messages 1001 - 2000
    [LoggerMessage(
       EventId = 0x1001,
       EventName = nameof(GenericMessages),
       Level = LogLevel.Debug,
       Message = "ENTRY:{caller}")]
    static partial void dbgEntryMessage(ILogger logger, string? caller);
    public static void DbgEntryMessage(this ILogger logger, [CallerMemberName]string? caller = null) { dbgEntryMessage(logger, caller); }

    [LoggerMessage(
        EventId = 0x1101,
        EventName = nameof(GenericMessages),
        Level = LogLevel.Debug,
        Message = "REQUEST:{requestName}")]
    static partial void dbgRequestMessage(ILogger logger, string requestName);
    public static void DbgRequestMessage(this ILogger logger, Type requestType) { dbgRequestMessage(logger, requestType.Name); }

    [LoggerMessage(
      EventId = 0x1102,
      EventName = nameof(GenericMessages),
      Level = LogLevel.Debug,
      Message = "RESPONSE:{response}, Duration:{duration}")]
    static partial void dbgResponseMessage(ILogger logger, string response, TimeSpan duration);
    public static void DbgResponseMessage(this ILogger logger, string response, long startTime) 
    {
        dbgResponseMessage(logger, response, Stopwatch.GetElapsedTime(startTime)); 
    }
    #endregion
    #region Information messages 2001 - 3000
    [LoggerMessage(
   EventId = 0x2001,
   EventName = nameof(GenericMessages),
   Level = LogLevel.Information,
   Message = "ENTRY:{caller}")]
    static partial void infEntryMessage(ILogger logger, string? caller);
    public static void InfEntryMessage(this ILogger logger, [CallerMemberName] string? caller = null) { infEntryMessage(logger, caller); }
    #endregion
    #region Warning messages 3001 - 4000
    [LoggerMessage(
   EventId = 0x3001,
   EventName = nameof(GenericMessages),
   Level = LogLevel.Warning,
   Message = "ENTRY:{caller}")]
    static partial void warEntryMessage(ILogger logger, string? caller);
    public static void WarEntryMessage(this ILogger logger, [CallerMemberName] string? caller = null) { warEntryMessage(logger, caller); }
    #endregion
    #region Error messages 4001 - 5000
    [LoggerMessage(
   EventId = 0x4001,
   EventName = nameof(GenericMessages),
   Level = LogLevel.Error,
   Message = "ENTRY:{caller}")]
    static partial void errEntryMessage(ILogger logger, string? caller);
    public static void ErrEntryMessage(this ILogger logger, [CallerMemberName] string? caller = null) { errEntryMessage(logger, caller); }
    #endregion
    #region Critical messages 5001 - 6000
    [LoggerMessage(
       EventId = 0x5001,
       EventName = nameof(GenericMessages),
       Level = LogLevel.Critical,
       Message = "ENTRY:{caller}")]
    static partial void crtEntryMessage(ILogger logger, string? caller);
    public static void CrtEntryMessage(this ILogger logger, [CallerMemberName] string? caller = null) { crtEntryMessage(logger, caller); }
    #endregion
}