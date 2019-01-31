using UnityEngine;

namespace Projectile
{
    public class ProjectileEmitter : MonoBehaviour
    {
        private int _shotsFired;
        private int _elapsedFrames;
        private Vector3 _emitterDirection;

        public int MaxShots;
        public float AngularVelocity; //degrees per second
        public float FixedUpdatesPerShot; //# of emits per second
        public float ProjectileInitialSpeed;
        public GameObject ProjectilePrefab;

        // Use this for initialization
        private void Start()
        {
            _emitterDirection = gameObject.transform.up; //use the up axis in 2D as the forward direction
        }

        // Use fixed update to generate projectile at a fixed delta time
        private void FixedUpdate()
        {
            if (_elapsedFrames > FixedUpdatesPerShot && _shotsFired <= MaxShots)
            {
                //Instantiate a projectile from a prefab
                //Initial position is inherited from the parent, i.e. the emitter
                //Rotation is Identity 
                var projectileSpawn = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);

                var rotation = Quaternion.AngleAxis(AngularVelocity * 1 / FixedUpdatesPerShot , new Vector3(0.0f, 0.0f, 1.0f));

                projectileSpawn.GetComponent<Projectile>().Velocity = _emitterDirection * ProjectileInitialSpeed;

                _emitterDirection = rotation * _emitterDirection;

                if (MaxShots > 0) _shotsFired++;
                _elapsedFrames = 0;
            }

            _elapsedFrames++;
        }
    }
}
