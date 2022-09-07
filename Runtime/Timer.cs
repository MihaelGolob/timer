using System;

/// <summary>
/// This is a Timer class that can be used instead of Coroutines and is more efficient.
/// It simply counts to the specified time amount and then invokes an event and sets a finished flag.
///
///
/// </summary>

// Made by: Mihael Golob, 01. 09. 2022
// send suggestions and questions to: golob.mihael@gmail.com
public class Timer {
    private readonly float _time;
    private readonly bool _loop;
    private readonly Action _callback;
    
    // internal
    private bool _isRunning;
    private float _timeElapsed;
    private bool _finished;
    private bool _dirty;

    // constructor (set isRunning to true automatically if startOnAwake is true)
    public Timer(float time, Action callback, bool loop = false, bool startOnAwake = true) =>
        (_time, _loop, _callback, _isRunning) = (time, loop, callback, startOnAwake);
    
    public Timer(float time, bool loop = false, bool startOnAwake = true) =>
        (_time, _loop, _isRunning) = (time, loop, startOnAwake);

    // public fields
    /// <summary>
    /// Normalized time elapsed.
    /// </summary>
    public float Progress => _timeElapsed / _time;

    /// <summary>
    /// Has the timer reached the specified time amount?
    /// This flag clears itself after read for the first time!
    /// </summary>
    public bool Finished {
        get {
            _dirty = true;
            return _finished;
        }
        private set => _finished = value;
    }
    
    /// <summary>
    /// Pause the timer.
    /// </summary>
    public bool Paused { get; set; }
    
    // PUBLIC METHODS -----------------------------------------------------------
    /// <summary>
    /// Method for updating the timer variables. Needs to be called every frame!
    /// </summary>
    /// <param name="deltaTime"></param>
    public void Update(float deltaTime) {
        // reset Finished flag, so it only returns true once
        if (_dirty) Finished = false;
        
        // return if not running
        if (!_isRunning || Paused) return;
        
        // update time elapsed
        _timeElapsed += deltaTime;
        
        // check if timer has ended
        if (_timeElapsed >= _time) {
            // invoke event
            _callback?.Invoke();
            
            // progress will be exactly 1.0
            _timeElapsed = _time;
            // set finished flag
            Finished = true;

            // repeat if needed
            if (_loop) StartTimer();
            else _isRunning = false;
        }
    }
    
    // start timer
    /// <summary>
    /// Start counting the timer.
    /// </summary>
    public void StartTimer() {
        _timeElapsed = 0f;
        _isRunning = true;
    }
}
