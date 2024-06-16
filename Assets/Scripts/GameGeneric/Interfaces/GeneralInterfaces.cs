public interface StepEvents
{
    /// <summary> This function need to be on FixedUpdate<br></br>Is normally used for read inputs and clear some things </summary>
    void BeforeStep();
    /// <summary> This function need to be on FixedUpdate after the BeforeStep<br></br>Is normally used for the core of the game object (movement ...) </summary>
    void Step();
    /// <summary> This function need to be on FixedUpdate after the Step<br></br>Is normally for timers or clear some things </summary>
    void AfterStep();
}