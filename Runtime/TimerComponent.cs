using UnityEngine;
using UnityEngine.Events;
using Ineor.Utils.Timer;

/// <summary>
/// This is a MonoBehaviour edition of the basic Timer utility.
/// Supports UnityEvents
/// </summary>
public class TimerComponent : MonoBehaviour {
    // inspector assigned
    [SerializeField] private float _time = 0.0f;
    [SerializeField] private bool _loop = false;
    [SerializeField] private bool _startOnAwake = false;
    [SerializeField] private UnityEvent _callback = null;
    
    // internal
    private Timer _timer;
    
    // public fields
    /// <summary>
    /// Normalized time elapsed.
    /// </summary>
    public float Progress => _timer.Progress;
    /// <summary>
    /// Has the timer reached the specified time amount?
    /// This flag clears itself after read for the first time!
    /// </summary>
    public bool Finished => _timer.Finished;
    /// <summary>
    /// Pause the timer.
    /// </summary>
    public bool Paused {
        get => _timer.Paused;
        set => _timer.Paused = value;
    }

    // UNITY EVENT METHODS ------------------------------------------------------------------
    
    private void OnEnable() {
        // instantiate timer with all needed properties
        _timer = new Timer(_time, () => _callback.Invoke(), _loop, _startOnAwake);
    }

    private void Update() {
        // update timer
        _timer.Update(Time.deltaTime);
    }
    
    // PUBLIC METHODS -----------------------------------------------------------------------
    public void StartTimer() {
        _timer.StartTimer();   
    }
}
