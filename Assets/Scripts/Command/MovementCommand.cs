using UnityEngine;

namespace Command
{
    public class MovementCommand : ICommand
    {
        private readonly Vector3 direction;
        private readonly float speed;
        private readonly Transform transformTarget;
        private readonly float deltaTime;

        public MovementCommand(Vector3 p_direction, float p_speed, Transform p_transformTarget, float p_deltaTime)
        {
            direction = p_direction;
            speed = p_speed;
            transformTarget = p_transformTarget;
            deltaTime = p_deltaTime;
        }

        public void Execute()
        {
            transformTarget.position += direction * (speed * deltaTime);
        }

        public void Undo()
        {
            transformTarget.position -= direction * (speed * deltaTime);
        }
    }
}