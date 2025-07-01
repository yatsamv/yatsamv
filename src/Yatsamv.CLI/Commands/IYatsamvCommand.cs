using Microsoft.Extensions.DependencyInjection;

namespace Yatsamv.CLI.Commands;

/// <summary>
/// Identifier for command within this application.
/// </summary>
public interface IYatsamvCommand
{
  /// <summary>
  /// Registers all necessary service dependencies used by the command.
  /// </summary>
  /// <param name="services"></param>
  static abstract void RegisterDependencies(IServiceCollection services);
}
