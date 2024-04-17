using UnityEngine;

namespace Strategy
{
    public class Shotgun : MonoBehaviour, IFireWeapon
    {
        public int Bullets { get; }

        public void Shoot()
        {
            //
        }

        public void Reload()
        {
        }
    }
}