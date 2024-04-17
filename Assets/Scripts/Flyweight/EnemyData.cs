using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Data/Enemy", order = 0)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int maxHealth;
    [SerializeField] private float speed;
    [field: SerializeField] public float IdleWaitTime { get; private set; }

    [field: SerializeField] public LayerMask PlayerLayer { get; private set; }
    [field: SerializeField] public float PlayerCheckRadius { get; private set; }
    [field: SerializeField] public float NearestPlayerCheckRadius { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }

    [field: SerializeField] public float ThresholdToPatrolPoint { get; private set; }
    public int MaxHealth => maxHealth;
}