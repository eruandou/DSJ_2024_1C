using Command;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "EnemyCreationCommandFactory", menuName = "Factory/EnemyCreationCommandFactory",
        order = 0)]
    public class EnemyCreationCommandGenerator : ScriptableObject
    {
        [SerializeField] private FactoryInitializer enemyFactoryInitializer;

        public bool TryGenerateEnemyCreationCommand(string enemyID, Vector3 position, out ICommand command)
        {
            var enemy = enemyFactoryInitializer.GetEnemy(enemyID);
            command = new CreateEnemyCommand(enemy, position);
            return command != null;
        }
    }
}