using System.Diagnostics;

namespace SeleniumTestsRunner.TestRunnerInfrastructure.Logger
{
    internal class CustomLogger : ILogger
    {
        static CustomLogger()
        {
            // Removing NUnit because it is duplicates messages in visual studio, 
            // Will not throw exception if Nunit is missing. 
            Trace.Listeners.Remove("NUnit");
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        public void Log(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
