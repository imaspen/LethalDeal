using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Projectile
{
    [Serializable]
    public class DelayedRotatingProjectileEmitter : ProjectileEmitter
    {
        private int _elapsedFrames;
        private Vector3 _emitterDirection;
        private int _shotsFired;
        private int _toShoot;

        public float RotationPerShot; //degrees per second

        // Use this for initialization
        private void Start()
        {
            _toShoot = FixedUpdatesPerShot == 0 ? MaxShots : 1;
            _emitterDirection = Quaternion.AngleAxis(StartingRotation, new Vector3(0.0f, 0.0f, 1.0f)) * transform.up;
        }

        private void FixedUpdate()
        {
            if (!isServer) return;
            if (_elapsedFrames % FixedUpdatesPerShot == 0 && (_shotsFired < MaxShots || MaxShots <= 0))
                for (var i = 0; i < _toShoot; i++)
                {
                    var projectileSpawn = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
                    var rotation = Quaternion.AngleAxis(RotationPerShot, new Vector3(0.0f, 0.0f, 1.0f));
                    projectileSpawn.GetComponent<Rigidbody2D>().velocity = _emitterDirection * ProjectileInitialSpeed;
                    _emitterDirection = rotation * _emitterDirection;
                    NetworkServer.Spawn(projectileSpawn);

                    if (MaxShots > 0) _shotsFired++;
                }

            _elapsedFrames++;
        }
    }
}