using System.Collections.Concurrent;

namespace Arlen.Server.Services;

public sealed class Dispatcher
{
    private readonly ConcurrentQueue<Action> _tasks = new();
    
    public void AddTask(Action task)
    {
        _tasks.Enqueue(task);
    }
    
    public void FlushPendingTasks()
    {
        while (_tasks.TryDequeue(out var task))
        {
            task?.Invoke();
        }
    }
}