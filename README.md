[![](https://img.shields.io/nuget/v/soenneker.webflow.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.webflow.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.webflow.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.webflow.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.webflow.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.webflow.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.webflow.httpclients/codeql.yml?style=for-the-badge&label=CodeQL)](https://github.com/soenneker/soenneker.webflow.httpclients/actions/workflows/codeql.yml)

# Soenneker.Webflow.HttpClients

Provides a cached `HttpClient` configured for the Webflow Data API v2 with Bearer-token authentication.

## Installation

```bash
dotnet add package Soenneker.Webflow.HttpClients
```

## Configuration

```json
{
  "Webflow": {
    "AccessToken": "your-webflow-access-token"
  }
}
```

The token may be a site token or an OAuth access token, but it must include the scopes required by the endpoints being called.

## Registration

```csharp
using Soenneker.Webflow.HttpClients.Registrars;

services.AddWebflowOpenApiHttpClientAsSingleton();
```

Scoped registration is available through `AddWebflowOpenApiHttpClientAsScoped()`. Each provider instance owns a separate cached client and removes only that client when disposed.

## Usage

```csharp
using Soenneker.Webflow.HttpClients.Abstract;

public sealed class SiteReader
{
    private readonly IWebflowOpenApiHttpClient _clients;

    public SiteReader(IWebflowOpenApiHttpClient clients)
    {
        _clients = clients;
    }

    public async ValueTask<HttpResponseMessage> GetSites(
        CancellationToken cancellationToken)
    {
        HttpClient client = await _clients.Get(cancellationToken);
        return await client.GetAsync("sites", cancellationToken);
    }
}
```

The base address is `https://api.webflow.com/v2/`, and requests include `Authorization: Bearer <AccessToken>` by default. Webflow API errors remain ordinary non-success HTTP responses for the caller to handle.
