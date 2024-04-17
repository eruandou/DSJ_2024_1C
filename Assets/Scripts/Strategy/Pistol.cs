using UnityEngine;

namespace Strategy
{
    public class Pistol : MonoBehaviour, IFireWeapon
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