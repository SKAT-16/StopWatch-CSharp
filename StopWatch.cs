using System;

namespace StopWatch {
  class StopWatch {

    TimeSpan timeSpan;
    DateTime startTime;
    bool isRunning;

    public StopWatch() {
      timeSpan = TimeSpan.Zero;
      isRunning = false;
    }

    public delegate void StopWatchEventHandler(string message);
    public event StopWatchEventHandler? OnStart, OnStop, OnReset;  



    public void Start() {
      if(!isRunning) {
        startTime = DateTime.Now - timeSpan;
        isRunning = true;
        OnStart?.Invoke("Stopwatch started");
      }
    }
    public void Stop() {}
    public void Reset() {}
    private void Tick() {}
  }
}