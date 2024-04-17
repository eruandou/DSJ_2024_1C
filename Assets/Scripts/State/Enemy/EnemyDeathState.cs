using UnityEngine;

namespace State.Enemy
{
    public class EnemyDeathState : EnemyState
    {
        public override void OnEnterState()
        {
            Debug.Log("Muelte");
        }

        public override void OnExecute(float deltaTime)
        {
        }

        public override void OnExitState()
        {
        }
    }
}