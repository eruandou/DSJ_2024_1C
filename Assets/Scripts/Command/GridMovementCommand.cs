using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class GridMovementCommand : IDeletableCommand
    {
        private List<EntityGridMovement> movements;

        public GridMovementCommand(List<EntityGridMovement> p_movements)
        {
            movements = p_movements;
        }


        public void Execute()
        {
            foreach (var entity in movements)
            {
                entity.transformToMove.position += entity.movementDirection * entity.lerpVelocity;
            }
        }

        public void Undo()
        {
            foreach (var entity in movements)
            {
                entity.transformToMove.position -= entity.movementDirection * entity.lerpVelocity;
            }
        }
    }

    public struct EntityGridMovement
    {
        public Vector3 movementDirection { get; }
        public float lerpVelocity { get; }
        public Transform transformToMove { get; }

        public EntityGridMovement(Vector3 p_movementDirection, float p_lerpVelocity, Transform p_transformToMove)
        {
            movementDirection = p_movementDirection;
            lerpVelocity = p_lerpVelocity;
            transformToMove = p_transformToMove;
        }
    }
}