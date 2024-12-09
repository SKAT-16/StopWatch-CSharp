using System;

namespace StopWatch {
  class StopWatch {

    TimeSpan timeSpan;
    bool isRunning;

    public delegate void StopWatchEventHandler(string message);
    public event StopWatchEventHandler OnStart, OnStop, OnReset;  



    void Start() {}
    void Stop() {}
    void Reset() {}
    void Tick() {}
  }
}