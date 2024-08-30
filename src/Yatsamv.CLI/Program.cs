using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using Microsoft.Extensions.Hosting;
using Yatsamv.CLI.Commands;

namespace Yatsamv.CLI;

internal static class Program
{
  // ReSharper disable once InconsistentNaming
  private static async Task<int> Main(string[] args)
  {
    var host = Host.CreateApplicationBuilder(args);
    return await new CommandLineBuilder(Cli.Build(host))
      .UseDefaults()
      .Build()
      .InvokeAsync(args)
      .ConfigureAwait(false);
  }
}
