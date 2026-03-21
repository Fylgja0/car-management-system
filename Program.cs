using CarProject_OOP.Procedure;

namespace CarProject_OOP
{
    // The Program class serves as the entry point of the application. It initializes the UXManager and starts the user interface loop.
    internal class Program
    {
        static void Main(string[] args)
        {
            UXManager uxManager = new();
            uxManager.Run();
        }
    }
}
