using StudentPortal;

internal class Program
{
    private static async Task Main(string[] args)
    {
        StudentRegistrationPortal portal = new();
        //var portal = new StudentRegistrationPortal();
        await portal.RunAsync();
    }
}
