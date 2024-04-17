using System;
using UnityEngine;

namespace State.Enemy
{
    public class EnemyPatrolState : EnemyState
    {
        private Transform[] patrolPoints;
        private int patrolPointIndex;
        private Transform enemyTransform;
        private float movementSpeed;
        private float thresholdToPatrolPoint;
        private Func<bool> getIsPlayerNear;

        public EnemyPatrolState(Transform[] patrolPoints, Transform enemyTransform, float movementSpeed,
            float thresholdToPatrolPoint, Func<bool> GetIsPlayerNear)
        {
            this.patrolPoints = patrolPoints;
            this.enemyTransform = enemyTransform;
            this.movementSpeed = movementSpeed;
            this.thresholdToPatrolPoint = thresholdToPatrolPoint;
            this.getIsPlayerNear = GetIsPlayerNear;
            patrolPointIndex = 0;
        }

        public override void OnEnterState()
        {
        }

        public override void OnExecute(float deltaTime)
        {
            var currentPoint = patrolPoints[patrolPointIndex];
            var directionToPatrolPoint = (currentPoint.position - enemyTransform.position).normalized;
            enemyTransform.position += directionToPatrolPoint * (deltaTime * movementSpeed);

            if (getIsPlayerNear())
            {
                OnStateChangePetitionHandle(EnemyStates.Pursuit);
                return;
            }

            if (GetIsOnPatrolPoint(currentPoint))
            {
                patrolPointIndex++;
                if (patrolPointIndex >= patrolPoints.Length)
                {
                    patrolPointIndex = 0;
                }

                OnStateChangePetitionHandle(EnemyStates.Idle);
            }
        }

        private bool GetIsOnPatrolPoint(Transform patrolPoint)
        {
            var distance = (patrolPoint.position - enemyTransform.position).magnitude;
            return distance <= thresholdToPatrolPoint;
        }

        public override void OnExitState()
        {
        }
    }
}