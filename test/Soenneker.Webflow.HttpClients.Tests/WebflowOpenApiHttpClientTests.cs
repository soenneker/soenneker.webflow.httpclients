using Soenneker.Webflow.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Webflow.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class WebflowOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IWebflowOpenApiHttpClient _httpclient;

    public WebflowOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IWebflowOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
