using AbstractFactory;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "NewFactoryInitializer", menuName = "Factory/EnemyInitializer", order = 0)]
    public class FactoryInitializer : ScriptableObject
    {
        private EnemyFactory enemyFactory = new();
        [SerializeField] private Enemy shadowPrefab;

        public Enemy GetEnemy(string enemyCode)
        {
            if (!enemyFactory.Initialized)
            {
                enemyFactory.Initialize(shadowPrefab);
            }

            return enemyFactory.CreateProduct(enemyCode);
        }
    }
}