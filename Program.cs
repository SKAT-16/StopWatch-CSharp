using System;

namespace StopWatch
{
  class Program
  {
    static void Main(string[] args)
    {
      StopWatch sw = new StopWatch();
      sw.OnStart += (message) => Console.WriteLine(message);
      sw.OnStop += (message) => Console.WriteLine(message);
      sw.OnReset += (message) => Console.WriteLine(message);

      Console.WriteLine("Console Stopwatch");
      Console.WriteLine("Commands: start (S), stop (T), reset (R), exit (E)");

      while (true)
      {
        if (Console.KeyAvailable)
        {
          var key = Console.ReadKey(true).Key;
          if (key == ConsoleKey.S) // Start
          {
            sw.Start();
          }
          else if (key == ConsoleKey.T) // Stop
          {
            sw.Stop();
          }
          else if (key == ConsoleKey.R) // Reset
          {
            sw.Reset();
          }
          else if (key == ConsoleKey.E) // Exit
          {
            sw.Stop();
            break;
          }
        }
      }

      Console.WriteLine("Thank you for using the stopwatch! Good Bye");
    }
  }
}