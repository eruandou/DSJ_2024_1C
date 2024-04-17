using System;
using UnityEngine;

namespace State.Enemy
{
    public class EnemyPursuitState : EnemyState
    {
        private Professor currentlyPursuitedPlayer;
        private Transform enemyTransform;
        private float movementSpeed;
        private Func<bool> getIsPlayerNear;
        private Func<Professor> getNearestPlayer;

        public EnemyPursuitState(Transform enemyTransform, float movementSpeed, Func<bool> GetIsPlayerNear,
            Func<Professor> GetNearestPlayer)
        {
            this.enemyTransform = enemyTransform;
            this.movementSpeed = movementSpeed;
            this.getIsPlayerNear = GetIsPlayerNear;
            this.getNearestPlayer = GetNearestPlayer;
        }

        public override void OnEnterState()
        {
            currentlyPursuitedPlayer = getNearestPlayer();
            if (currentlyPursuitedPlayer == null)
            {
                currentlyPursuitedPlayer = null;
                OnStateChangePetitionHandle(EnemyStates.Idle);
            }
        }

        public override void OnExecute(float deltaTime)
        {
            var directionToPlayer = (currentlyPursuitedPlayer.transform.position - enemyTransform.position).normalized;
            var movement = directionToPlayer * (movementSpeed * deltaTime);
            enemyTransform.position += movement;

            if (getIsPlayerNear())
                return;
            currentlyPursuitedPlayer = null;
            OnStateChangePetitionHandle(EnemyStates.Idle);
        }

        public override void OnExitState()
        {
        }
    }
}