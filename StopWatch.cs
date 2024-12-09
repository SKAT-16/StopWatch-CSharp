using System;

namespace StopWatch
{
  class StopWatch
  {

    TimeSpan timeSpan;
    DateTime startTime;
    bool isRunning;

    public StopWatch()
    {
      timeSpan = TimeSpan.Zero;
      isRunning = false;
    }

    public delegate void StopWatchEventHandler(string message);
    public event StopWatchEventHandler? OnStart, OnStop, OnReset;



    public void Start()
    {
      if (!isRunning)
      {
        startTime = DateTime.Now - timeSpan;
        isRunning = true;
        OnStart?.Invoke("Stopwatch started");
        Tick();
      }
    }
    public void Stop()
    {
      if (isRunning)
      {
        isRunning = false;
        timeSpan = DateTime.Now - startTime;
        OnStop?.Invoke($"Stopwatch stopped. Total time:  {timeSpan:hh\\:mm\\:ss}");
      }
    }
    public void Reset()
    {
      isRunning = false;
      timeSpan = TimeSpan.Zero;
      OnReset?.Invoke("Stopwatch reset");
    }
    private void Tick()
    {
      while (isRunning)
      {
        timeSpan = DateTime.Now - startTime;
        Console.Write($"\rElapsed Time: {timeSpan:hh\\:mm\\:ss}");
        Thread.Sleep(100);
      }
    }
  }
}