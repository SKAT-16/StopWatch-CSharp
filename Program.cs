using System;

namespace StopWatch
{
  class Program
  {

    static void HandleStart(string message)
    {
      Console.WriteLine("\nStart event triggered");
      Console.WriteLine(message);
    }

    static void HandleStop(string message)
    {
      Console.WriteLine("\nStop event triggered");
      Console.WriteLine(message);
    }
    static void HandleReset(string message)
    {
      Console.WriteLine("\nReset event triggered");
      Console.WriteLine(message);
    }


    static void Main(string[] args)
    {
      Console.BackgroundColor = ConsoleColor.Black;
      Console.ForegroundColor = ConsoleColor.White;
      Console.Clear();

      StopWatch sw = new StopWatch();
      sw.OnStart += HandleStart;
      sw.OnStop += HandleStop;
      sw.OnReset += HandleReset;

      Console.WriteLine("Console Stopwatch");
      Console.WriteLine("Commands: start (S), stop (T), reset (R), exit (E)");
      Console.WriteLine("Press any key to exit");

      var instructions = "Type 's' to start, 't' to stop, 'r' to reset, 'e' to exit";
      var line = new string('-', instructions.Length);
      Console.WriteLine(instructions);
      Console.WriteLine(line);

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

      Console.BackgroundColor = ConsoleColor.Black;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.Clear();
      Console.WriteLine("Thank you for using the stopwatch! Good Bye");
    }
  }
}