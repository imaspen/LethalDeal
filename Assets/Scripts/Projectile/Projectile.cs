using UnityEngine;
using UnityEngine.Networking;

namespace Projectile
{
    public class Projectile : NetworkBehaviour
    {

        [SyncVar] public float MaxLifeTime;
        [SyncVar] public Vector3 MaxSize;

        private Vector3 _initialSize;
        private float _elapsedTimeAlive;
        private Collider2D _collider2D;

        // Use this for initialization
        private void Start()
        {
            _initialSize = gameObject.transform.localScale;
            _elapsedTimeAlive = 0.0f;
        }

        // Use fixed update to compute the position of a projectile at a fixed interval
        void FixedUpdate()
        {
            var scale = _initialSize + MaxSize * Mathf.Sin(_elapsedTimeAlive / MaxLifeTime * Mathf.PI);
            transform.localScale = scale;
            _elapsedTimeAlive += Time.fixedDeltaTime;

            if (_elapsedTimeAlive > MaxLifeTime && isServer)
                NetworkServer.Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!isServer) return;
            if (other.gameObject.CompareTag(gameObject.tag) || other.gameObject.CompareTag("Card")) return;
            other.GetComponent<HPController>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
