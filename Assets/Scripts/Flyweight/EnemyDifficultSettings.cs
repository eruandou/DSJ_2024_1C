using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "NewEnemyDifficultySettings", menuName = "Data/DifficultySettings/Enemy", order = 0)]
    public class EnemyDifficultSettings : ScriptableObject
    {
        [SerializeField] private List<Enemy> enemiesToSpawn;

        public List<Enemy> EnemiesToSpawn => enemiesToSpawn;
    }
}