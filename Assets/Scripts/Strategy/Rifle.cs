using UnityEngine;

namespace Strategy
{
    public class Rifle : MonoBehaviour, IFireWeapon
    {
        public int Bullets { get; }

        public void Shoot()
        {
        }

        public void Reload()
        {
        }
    }
}