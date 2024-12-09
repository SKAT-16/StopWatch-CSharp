using System;
using System.Threading;

namespace StopWatch
{
  class StopWatch
  {

    TimeSpan timeSpan;
    DateTime startTime;
    bool isRunning;
    Thread? tickThread;

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
        tickThread = new Thread(Tick);
        tickThread.Start();
      }
    }
    public void Stop()
    {
      if (isRunning)
      {
        isRunning = false;
        tickThread?.Join();
        timeSpan = DateTime.Now - startTime;
        OnStop?.Invoke($"Stopwatch stopped. Total time:  {timeSpan:hh\\:mm\\:ss}");
      }
    }
    public void Reset()
    {
      isRunning = false;
      tickThread?.Join();
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