using System.Diagnostics;
using Arlen.Server.Game;
using Microsoft.Extensions.Hosting;

namespace Arlen.Server.Services;

public class GameLoop : BackgroundService
{
    private readonly Dispatcher _dispatcher;
    private readonly World _world;

    public GameLoop(Dispatcher dispatcher, World world)
    {
        _dispatcher = dispatcher;
        _world = world;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var tickRate = TimeSpan.FromMilliseconds(50);
        var stopwatch = Stopwatch.StartNew();
        var accumulated = TimeSpan.Zero;

        var timer = new PeriodicTimer(tickRate);

        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            accumulated += stopwatch.Elapsed;
            stopwatch.Restart();

            while (accumulated >= tickRate)
            {
                _dispatcher.FlushPendingTasks();
                _world.Update(tickRate);
                
                accumulated -= tickRate;
            }
        }
    }
}