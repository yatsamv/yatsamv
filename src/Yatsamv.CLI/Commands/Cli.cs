using System.CommandLine;
using Microsoft.Extensions.Hosting;

namespace Yatsamv.CLI.Commands;

public class Cli : RootCommand
{
  private Cli()
  {
  }

  public static Cli Build(HostApplicationBuilder builder)
  {
    var cmd = new Cli { Description = "Yatsamv CLI" };
    return cmd;
  }
}
