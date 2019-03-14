using UnityEngine;
using UnityEngine.Networking;

namespace Projectile
{
    public abstract class ProjectileEmitter : NetworkBehaviour
    {
        public int FixedUpdatesPerShot; //# of emits per second
        public int MaxShots;
        public float ProjectileInitialSpeed;
        public GameObject ProjectilePrefab;
        public float StartingRotation;
    }
}