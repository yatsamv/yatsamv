using System.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Yatsamv.CLI.Commands;

/// <inheritdoc />
public class RenderCommand : Command, IYatsamvCommand
{
  private const string CommandName = "render";
  private const string CommandDescription = "Renders the files to images";

  /// <inheritdoc />
  public RenderCommand(IServiceProvider serviceProvider) : base(CommandName, CommandDescription)
  {
    this.SetHandler(() => serviceProvider.GetRequiredService<IHost>().Run());
  }

  /// <inheritdoc />
  public static void RegisterDependencies(IServiceCollection services) { }
}
