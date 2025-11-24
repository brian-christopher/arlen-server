using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Arlen.Services;

using DispatcherTask = Func<ValueTask>;

public class Dispatcher
{
    private readonly ConcurrentQueue<Action> _tasks = new(); 
    private readonly ILogger<Dispatcher> _logger;

    public Dispatcher(ILogger<Dispatcher> logger)
    {
        _logger = logger;
    }

    public void AddTask(Action task)
    {
        _tasks.Enqueue(task); 
    }

    public void FlushPending()
    {
        while(_tasks.TryDequeue(out var task))
        {
            task();
        }
    }
}