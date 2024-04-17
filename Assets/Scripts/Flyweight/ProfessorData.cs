using UnityEngine;

[CreateAssetMenu(fileName = "NewProfessorData", menuName = "Data/ProfessorData")]
public class ProfessorData : ScriptableObject
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float interactionRadius;
    [SerializeField] private LayerMask interactionMask;
    [SerializeField] private LayerMask damageableMask;
    [SerializeField] private GameObject bulletPrefab;

    public GameObject instantiatedBullet;
    public LayerMask InteractionMask => interactionMask;
    public float MovementSpeed => movementSpeed;
    public float InteractionRadius => interactionRadius;

    public LayerMask DamageableMask => damageableMask;
    public GameObject BulletPrefab => bulletPrefab;
}