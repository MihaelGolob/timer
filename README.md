# timer
**A unity package for a simple timer without using coroutines**

The package contains a simple timer class that can be used to measure time. In addition it also packs a MonoBehaviour script
which can be used a timer on objects and can trigger an Unity Event.

**usage**

1. Create a Timer object with one of the constructors.
2. Start the timer with the Start() method (if not started on awake).
3. call the Update() method every frame.
4. wait for the callback method or check if Finished property is true.

**examples of usage**

This package can be used virtually anywhere you would instead use a coroutine with a 
yield return new WaitForSeconds() instruction. It is very lightweight and fast so there is
little overhead.