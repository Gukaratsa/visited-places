using Microsoft.Extensions.DependencyInjection;
using VisitedPlaces.Shared.Behaviours;
using System.Reflection;
using MediatR;

namespace VisitedPlaces.Shared;

public static class MediatRExtensions
{
    public static IServiceCollection AddMediatR_FromExeFolder(this IServiceCollection serviceDescriptors)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var exePath = Path.GetDirectoryName(assembly.Location) 
            ?? throw new NullReferenceException($"Could not find directory for assembly:{assembly.FullName}");
        var dllFiles = Directory.GetFiles(exePath, "*.dll");
        var dllAssemblies = dllFiles.Select(x => Assembly.LoadFrom(x));
        var assemblies = new Assembly[] { assembly }.Concat(dllAssemblies).ToArray();
        serviceDescriptors.AddMediatR((config) => config
            .RegisterServicesFromAssemblies(assemblies));
        serviceDescriptors.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        return serviceDescriptors;
    }
}
