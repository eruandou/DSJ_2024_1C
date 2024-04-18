using UnityEngine;

namespace Helpers
{
    public static class RandomPosition
    {
        private static readonly Vector2 MapLimitsX = new Vector2(0, 20);
        private static readonly Vector2 MapLimitsZ = new Vector2(0, 20);

        public static Vector3 GetRandomPositionInLimits()
        {
            var randomX = Random.Range(MapLimitsX.x, MapLimitsX.y);
            var randomZ = Random.Range(MapLimitsZ.x, MapLimitsZ.y);

            return new Vector3(randomX, 0, randomZ);
        }
    }
}