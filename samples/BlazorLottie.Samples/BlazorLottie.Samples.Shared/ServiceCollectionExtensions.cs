using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedComponents(this IServiceCollection services)
    {
        return services
               .AddBlazorise(opts =>
               {
                   opts.Immediate = true;
               })
               .AddBootstrapProviders()
               .AddBootstrapComponents()
               .AddFontAwesomeIcons();
    }
}