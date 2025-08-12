using System;
using System.Collections.Generic;

public class Process
{
    public string Pid { get; }
    public int Time { get; set; }
    public Process(string pid, int time)
    {
        Pid = pid;
        Time = time;
    }
}

public class Scheduler
{
    private readonly Queue<Process> _processes;
    private readonly int _quantum;

    public int Quantum => _quantum;
    public int ProcessCount => _processes.Count;

    public Scheduler(Queue<Process> processes, int quantum)
    {
        _processes = processes;
        _quantum = quantum;
    }

    public void Run()
    {
        while (_processes.Count > 0)
        {
            var process = _processes.Dequeue();
            int runTime = Math.Min(_quantum, process.Time);
            Console.WriteLine($"Running {process.Pid} for {runTime} units.");
            if (process.Time > _quantum)
            {
                process.Time -= _quantum;
                _processes.Enqueue(process);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        var processes = new Queue<Process>(new[]
        {
            new Process("P1", 5),
            new Process("P2", 3),
            new Process("P3", 8)
        });

        var scheduler = new Scheduler(processes, 2);
        scheduler.Run();
    }
}