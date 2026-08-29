[![](https://img.shields.io/nuget/v/soenneker.webflow.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.webflow.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.webflow.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.webflow.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.webflow.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.webflow.httpclients/)

# Soenneker.Webflow.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.Webflow.HttpClients
```

## Quick start

```csharp
using Soenneker.Webflow.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddWebflowOpenApiHttpClientAsSingleton();
```

Adds `WebflowOpenApiHttpClient` as a singleton service.

## What you get

- `IWebflowOpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `WebflowOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `WebflowOpenApiHttpClientRegistrar.AddWebflowOpenApiHttpClientAsSingleton(services)` | Adds `WebflowOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `WebflowOpenApiHttpClientRegistrar.AddWebflowOpenApiHttpClientAsScoped(services)` | Adds `WebflowOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
