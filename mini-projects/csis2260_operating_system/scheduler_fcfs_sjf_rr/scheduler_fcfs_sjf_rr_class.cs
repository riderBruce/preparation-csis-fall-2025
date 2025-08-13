using System;
using System.Collections.Generic;

public class Process
{
    public string Pid { get; }
    public int Remaining { get; set; }
    public Process(string pid, int remaining)
    {
        Pid = pid;
        Remaining = remaining;
    }
}

public interface ISchedulingStrategy
{
    Process DequeueNext(Queue<Process> readyQueue);
}

public sealed class FcfsStrategy : ISchedulingStrategy
{
    public Process DequeueNext(Queue<Process> readyQueue) => readyQueue.Dequeue();
}

public sealed class SjfStrategy : ISchedulingStrategy
{
    public Process DequeueNext(Queue<Process> readyQueue)
    {
        Process best = null!;
        int n = readyQueue.Count;
        for (int i = 0; i < n; i++)
        {
            var p = readyQueue.Dequeue();
            if (best == null || p.Remaining < best.Remaining)
            {
                if (best != null) readyQueue.Enqueue(best);
                best = p;
            }
            else
            {
                readyQueue.Enqueue(p);
            }
        }
        return best;
    }
}

public sealed class RrStrategy : ISchedulingStrategy
{
    public Process DequeueNext(Queue<Process> readyQueue) => readyQueue.Dequeue();
}

public class Scheduler
{
    private readonly Queue<Process> _ready;
    private readonly ISchedulingStrategy _stratagy;
    private readonly int _quantum;

    public Scheduler(Queue<Process> ready, ISchedulingStrategy strategy, int quantum)
    {
        _ready = ready;
        _stratagy = strategy;
        _quantum = quantum;
    }

    public void Run()
    {
        while (_ready.Count > 0)
        {
            var p = _stratagy.DequeueNext(_ready);
            int run = Math.Min(_quantum, p.Remaining);
            Console.WriteLine($"Running {p.Pid} for {run} units");
            p.Remaining -= run;
            if (p.Remaining > 0) _ready.Enqueue(p);
        }
    }
}

public static class Demo
{
    public static void Main()
    {
        var ready = new Queue<Process>(new[]
        {
            new Process("P1", 5),
            new Process("P2", 3),
            new Process("P3", 8)
        });

        ISchedulingStrategy fcfs = new FcfsStrategy();
        ISchedulingStrategy sjf = new SjfStrategy();
        ISchedulingStrategy rr = new RrStrategy();

        Console.WriteLine("FCFS: ");
        new Scheduler(new Queue<Process>(ready), fcfs, int.MaxValue).Run();
        Console.WriteLine("SJF: ");
        new Scheduler(new Queue<Process>(ready), sjf, int.MaxValue).Run();
        Console.WriteLine("RR: ");
        new Scheduler(new Queue<Process>(ready), rr, 2).Run();
    }
}