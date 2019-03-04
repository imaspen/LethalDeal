using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Projectile
{
    public abstract class ProjectileEmitter : NetworkBehaviour
    {
        public GameObject ProjectilePrefab;
    }
}