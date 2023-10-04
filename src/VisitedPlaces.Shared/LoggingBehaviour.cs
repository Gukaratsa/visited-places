using Microsoft.Extensions.Logging;
using System.Text.Json;
using MediatR;
using System.Diagnostics;

namespace VisitedPlaces.Shared.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

    public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.DbgRequestMessage(typeof(TRequest));
        var sw = Stopwatch.GetTimestamp();
        var response = await next();
        _logger.DbgResponseMessage(JsonSerializer.Serialize(response), sw);
        return response;
    }
}