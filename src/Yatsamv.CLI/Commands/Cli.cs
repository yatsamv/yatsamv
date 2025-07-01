using System.CommandLine;
using System.CommandLine.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Yatsamv.CLI.Commands;

#pragma warning disable CA1724
/// <inheritdoc />
public class Cli : RootCommand
{
  private Cli()
  {
  }

  /// <summary>
  /// Creates a <see cref="CommandLineBuilder"/> with command registered as part of the options.
  /// </summary>
  /// <param name="builder"></param>
  /// <param name="options"></param>
  /// <returns></returns>
  public static CommandLineBuilder CreateBuilder(HostApplicationBuilder builder, Action<HostApplicationBuilder> options)
  {
    ArgumentNullException.ThrowIfNull(builder);
    ArgumentNullException.ThrowIfNull(options);

    options.Invoke(builder);

    var commands = builder.Build().Services.GetServices<Command>();
    var rootCommand = new Cli { Description = "Yatsamv CLI" };
    foreach (var command in commands)
    {
      rootCommand.AddCommand(command);
    }

    return new CommandLineBuilder(rootCommand).UseDefaults();
  }
}
