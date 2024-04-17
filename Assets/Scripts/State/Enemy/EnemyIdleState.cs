using System;

public class EnemyIdleState : EnemyState
{
    private float elapsedTime;
    private float idleWaitTime;
    private Func<bool> getIsPlayerNear;

    public EnemyIdleState(float idleWaitTime, Func<bool> GetIsPlayerNear)
    {
        this.idleWaitTime = idleWaitTime;
        this.getIsPlayerNear = GetIsPlayerNear;
    }

    public override void OnEnterState()
    {
        elapsedTime = 0;
    }

    public override void OnExecute(float deltaTime)
    {
        elapsedTime += deltaTime;
        if (elapsedTime >= idleWaitTime)
        {
            bool isPlayerNear = getIsPlayerNear();

            if (isPlayerNear)
            {
                OnStateChangePetitionHandle(EnemyStates.Pursuit);
                return;
            }

            OnStateChangePetitionHandle(EnemyStates.Patrol);
        }
    }

    public override void OnExitState()
    {
    }
}