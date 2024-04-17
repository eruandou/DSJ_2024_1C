using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace State
{
    public static class EnemyHelper
    {
        public static bool GetIsPlayerNear(Transform enemyTransform, float checkRadius, Collider[] nearPlayers, LayerMask playerLayer)
        {
            int foundPlayerCount =
                Physics.OverlapSphereNonAlloc(enemyTransform.position, checkRadius, nearPlayers, playerLayer);

            if (foundPlayerCount < 1)
            {
                return false;
            }

            for (int i = 0; i < foundPlayerCount; i++)
            {
                var currentPlayer = nearPlayers[i];
                var currentProfessor = currentPlayer.GetComponent<Professor>();
                if (currentProfessor != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}