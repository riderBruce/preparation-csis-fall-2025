public delegate void Notify(string message);  // like a method signature

public class Broadcaster
{
    public Notify OnBroadcast;  // a delegate variable

    public void BroadcastSomething()
    {
        OnBroadcast?.Invoke("Broadcast from studio!");
    }
}

public class Listener
{
    public void React(string msg)
    {
        Console.WriteLine($"🎧 Listener got: {msg}");
    }
}

public class Program
{
    public static void Main()
    {
        Broadcaster radio = new();
        Listener user = new();

        radio.OnBroadcast = user.React;  // delegate points to method
        radio.BroadcastSomething();      // Output: 🎧 Listener got: Broadcast from studio!


        EventBroadcaster radio = new();
        radio.OnBroadcast += user.React;
        radio.BroadcastSomething(); // 🎧 Listener got: Event-based broadcast!

    }
}

public class EventBroadcaster
{
    public event Notify? OnBroadcast;

    public void BroadcastSomething()
    {
        OnBroadcast?.Invoke("Event-based broadcast!");
    }
}
