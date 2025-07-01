using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Yatsamv.CLI.Commands;

namespace Yatsamv.CLI;

internal static class Program
{
  // ReSharper disable once InconsistentNaming
  private static async Task<int> Main(string[] args)
  {
    var host = Host.CreateApplicationBuilder(args);
    host.Services
      .TryAddCommand<RenderCommand>()
      .TryAddCommand<RenderCommand>();

    return await Cli.CreateBuilder(host, _ => { })
      .Build()
      .InvokeAsync(args)
      .ConfigureAwait(false);
  }

  private static IServiceCollection TryAddCommand<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this IServiceCollection services) where T : Command, IYatsamvCommand
  {
    if (services.FirstOrDefault(sd => sd.ImplementationType == typeof(T)) != default)
    {
      return services;
    }

    T.RegisterDependencies(services);
    return services.AddSingleton<Command, T>();
  }
}
