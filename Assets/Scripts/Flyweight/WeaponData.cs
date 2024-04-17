using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "NewWeaponData", menuName = "Data/Weapons")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private float damage;
        [SerializeField] private string weaponName;
        [SerializeField] private Mesh weaponMesh;
        [SerializeField] private GameObject bullet;
    }
}