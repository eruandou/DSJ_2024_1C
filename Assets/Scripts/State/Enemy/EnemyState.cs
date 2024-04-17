using System;

public abstract class EnemyState : StateBase
{
    public event Action<EnemyStates> OnStateChangePetition;

    protected void OnStateChangePetitionHandle(EnemyStates newState)
    {
        OnStateChangePetition?.Invoke(newState);
    }
}