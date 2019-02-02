using UnityEngine;

namespace Projectile
{
    public class ProjectileEmitter : MonoBehaviour
    {
        private int _shotsFired;
        private int _elapsedFrames;
        private Vector3 _emitterDirection;

        public int MaxShots;
        public float StartingRoation;
        public float RotationPerShot; //degrees per second
        public float FixedUpdatesPerShot; //# of emits per second
        public float ProjectileInitialSpeed;
        public GameObject ProjectilePrefab;

        // Use this for initialization
        private void Start()
        {
            _emitterDirection = Quaternion.AngleAxis(StartingRoation, new Vector3(0.0f, 0.0f, 1.0f)) * transform.up;
        }

        private void FixedUpdate()
        {
            if (_elapsedFrames > FixedUpdatesPerShot && _shotsFired <= MaxShots)
            {
                var projectileSpawn = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
                var rotation = Quaternion.AngleAxis(RotationPerShot, new Vector3(0.0f, 0.0f, 1.0f));

                projectileSpawn.GetComponent<Projectile>().Velocity = _emitterDirection * ProjectileInitialSpeed;
                _emitterDirection = rotation * _emitterDirection;
                if (MaxShots > 0) _shotsFired++;
                _elapsedFrames = 0;
            }

            _elapsedFrames++;
        }
    }
}
