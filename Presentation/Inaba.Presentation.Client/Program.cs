using Grpc.Net.Client.Web;
using Grpc.Net.Client;
using Inaba.Presentation.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HTTP
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// GRPC
builder.Services.AddSingleton(services =>
{
    var url = (builder.Configuration["serverUrl"]) ?? throw new NullReferenceException("Server‚ÌUrl‚ªÝ’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");

    var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler());
    return GrpcChannel.ForAddress(url, new GrpcChannelOptions { HttpHandler = httpHandler });
});

// GoogleOIDC
builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("GoogleOIDC", options.ProviderOptions);
});


await builder.Build().RunAsync();
