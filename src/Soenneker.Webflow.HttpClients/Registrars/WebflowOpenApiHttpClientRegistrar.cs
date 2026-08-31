using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Webflow.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Webflow.HttpClients.Registrars;

/// <summary>
/// Registers authenticated HTTP clients for the Webflow Data API v2.
/// </summary>
public static class WebflowOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="WebflowOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddWebflowOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IWebflowOpenApiHttpClient, WebflowOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="WebflowOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddWebflowOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IWebflowOpenApiHttpClient, WebflowOpenApiHttpClient>();

        return services;
    }
}
