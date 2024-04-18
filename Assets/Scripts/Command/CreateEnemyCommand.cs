using Unity.Mathematics;
using UnityEngine;

namespace Command
{
    public class CreateEnemyCommand : IDeletableCommand
    {
        private Enemy _prefab;
        private Vector3 _position;
        private Enemy _instance;

        public CreateEnemyCommand(Enemy p_prefab, Vector3 p_position)
        {
            _prefab = p_prefab;
            _position = p_position;
        }

        public void Execute()
        {
            _instance = Object.Instantiate(_prefab, _position, quaternion.identity);
        }

        public void Undo()
        {
            if (_instance != null)
            {
                Object.Destroy(_instance.gameObject);
            }
        }
    }
}