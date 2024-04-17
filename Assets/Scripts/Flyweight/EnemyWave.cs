using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "NewEnemyWave", menuName = "Data/Enemies/Waves", order = 0)]
    public class EnemyWave : ScriptableObject
    {
        [SerializeField] private List<Enemy> enemiesToSpawn;
        [SerializeField] private float waveTime;
        [SerializeField] private int enemiesInWave;

        public float WaveTime => waveTime;
        public int EnemiesInWave => enemiesInWave;

        public Enemy GetRandomEnemy()
        {
            var randomIndex = Random.Range(0, enemiesToSpawn.Count);
            return enemiesToSpawn[randomIndex];
        }
    }
}