using System;
using UnityEngine;

namespace Projectile
{
    [Serializable]
    public class ProjectileEmitter : MonoBehaviour
    {
        private int _shotsFired;
        private int _elapsedFrames;
        private Vector3 _emitterDirection;

        public int MaxShots;
        public float StartingRotation;
        public float RotationPerShot; //degrees per second
        public int FixedUpdatesPerShot; //# of emits per second
        public float ProjectileInitialSpeed;
        public GameObject ProjectilePrefab;

        // Use this for initialization
        private void Start()
        {
            _emitterDirection = Quaternion.AngleAxis(StartingRotation, new Vector3(0.0f, 0.0f, 1.0f)) * transform.up;
        }

        private void FixedUpdate()
        {
            if (_elapsedFrames % FixedUpdatesPerShot == 0 && _shotsFired <= MaxShots)
            {
                Debug.Log(_elapsedFrames);
                var toShoot = 1;
                if (FixedUpdatesPerShot == 0) toShoot = MaxShots;
                for (var i = 0; i < toShoot; i++)
                {
                    var projectileSpawn = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
                    var rotation = Quaternion.AngleAxis(RotationPerShot, new Vector3(0.0f, 0.0f, 1.0f));
    
                    projectileSpawn.GetComponent<Projectile>().Velocity = _emitterDirection * ProjectileInitialSpeed;
                    _emitterDirection = rotation * _emitterDirection;
                    if (MaxShots > 0) _shotsFired++;
                }
            }

            _elapsedFrames++;
        }
    }
}
