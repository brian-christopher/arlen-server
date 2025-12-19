using Microsoft.Extensions.Hosting;
using SuperSocket.WebSocket.Server;

var host = WebSocketHostBuilder.Create()
    .Build();

await host.RunAsync();