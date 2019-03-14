using UnityEngine;
using UnityEngine.Networking;

namespace Projectile
{
    public class SpreadShotProjectileEmitter : ProjectileEmitter
    {
        private int _elapsedFrames;
        private Vector3 _emitterDirection;
        private Quaternion _rotationPerShot;
        private int _shotsFired;
        private int _toShoot;
        public float ShotsInSpread;

        public float SpreadAngle;

        private void Start()
        {
            _emitterDirection = Quaternion.AngleAxis(StartingRotation - SpreadAngle / 2, new Vector3(0, 0, 1)) *
                                Vector3.up;
            _rotationPerShot = Quaternion.AngleAxis(SpreadAngle / (ShotsInSpread - 1), new Vector3(0, 0, 1));
        }

        private void FixedUpdate()
        {
            if (!isServer) return;
            if (_elapsedFrames % FixedUpdatesPerShot == 0 && (_shotsFired < MaxShots || MaxShots <= 0))
            {
                var direction = _emitterDirection;
                for (var i = 0; i < ShotsInSpread; i++)
                {
                    var projectileSpawn = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
                    projectileSpawn.GetComponent<Rigidbody2D>().velocity = direction * ProjectileInitialSpeed;
                    NetworkServer.Spawn(projectileSpawn);
                    direction = _rotationPerShot * direction;
                }

                if (MaxShots > 0) _shotsFired++;
            }

            _elapsedFrames++;
        }
    }
}