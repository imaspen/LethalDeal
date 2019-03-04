using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Projectile
{
    public abstract class ProjectileEmitter : NetworkBehaviour
    {
        public GameObject ProjectilePrefab;
        public float ProjectileInitialSpeed;
        public int FixedUpdatesPerShot; //# of emits per second
        public int MaxShots;
        public float StartingRotation;
    }
}