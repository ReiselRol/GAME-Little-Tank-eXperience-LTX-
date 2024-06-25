/// <summary>
/// This class is for Make the Timers cooldown for abilities or something easy to use and
/// with that is not necessary repeat code
/// </summary>
public class Timer
{
    /// <summary> This is the actual timer value, if is > 0 then the timer is not finished</summary>
    private int TicksRemaining = 0;
    /// <summary> This Propertie is for the restart value, when you restart how many time you want to wait?</summary>
    private int MaxTicks = 0;

    public Timer (int TicksRemaining, int MaxTicks)
    {
        this.TicksRemaining = TicksRemaining;
        this.MaxTicks = MaxTicks;
    }
    public Timer(int MaxTicks)
    {
        this.MaxTicks = MaxTicks;
    }
    /// <summary> This function simply set the value of the TicksRemaining to the MaxTicks</summary>
    public void Reset ()
    {
        this.TicksRemaining = this.MaxTicks;
    }
    /// <summary> This Function will reduce if can the TicksRemaining</summary>
    /// <param name="quantity">For default the reduction is by 1 but you can configurate for more or less</param>
    public void ReduceTimer (int quantity = 1)
    {
        if (this.TicksRemaining > 0)
        {
            this.TicksRemaining -= quantity;
        }
    }
    /// <summary> This function is for check if the timerRemaining reach 0</summary>
    /// <returns> Return a bool of true if the timer reach or ovepass the 0 value</returns>
    public bool IsFinished ()
    {
        return this.TicksRemaining <= 0;
    }
    /// <summary>This is for set the cooldown</summary>
    /// <param name="ActualTicks">the ticks you gonna set to cooldown</param>
    public void setActualTicks (int ActualTicks)
    {
        this.TicksRemaining = ActualTicks;
    }
}
