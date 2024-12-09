using System;

namespace StopWatch
{
  class Program
  {

    static void HandleStart(string message)
    {
      Console.WriteLine("Start event triggered");
      Console.WriteLine(message);
    }

    static void HandleStop(string message)
    {
      Console.WriteLine("Stop event triggered");
      Console.WriteLine(message);
    }
    static void HandleReset(string message)
    {
      Console.WriteLine("Reset event triggered");
      Console.WriteLine(message);
    }
    static void Main(string[] args)
    {
      StopWatch sw = new StopWatch();
      sw.OnStart += HandleStart;
      sw.OnStop += HandleStop;
      sw.OnReset += HandleReset;

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