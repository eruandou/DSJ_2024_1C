using UnityEngine;

namespace Command
{
    public class PhysicsMovementCommand : ICommand
    {
        private readonly Vector3 forceDirection;
        private readonly float forceIntensity;
        private readonly Rigidbody targetRigidbody;

        public PhysicsMovementCommand(Vector3 p_forceDirection, float p_forceIntensity, Rigidbody p_targetRigidbody)
        {
            forceDirection = p_forceDirection;
            forceIntensity = p_forceIntensity;
            targetRigidbody = p_targetRigidbody;
        }

        public void Execute()
        {
            targetRigidbody.AddForce(forceDirection * forceIntensity);
        }
    }
}