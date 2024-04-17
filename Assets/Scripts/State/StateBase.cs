
public abstract class StateBase
{
    /// <summary>
    /// Used when entering a state. Should reset inner variables and states. 
    /// </summary>
    public abstract void OnEnterState();

    public abstract void OnExecute(float deltaTime);
    public abstract void OnExitState();
}