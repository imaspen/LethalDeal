using UnityEngine;
using UnityEngine.Networking;

namespace Gunner
{
    public class GunnerFireController : NetworkBehaviour
    {

        public Transform FirePoint;
        public GameObject BulletPrefab;
        public float Period;

        private NetworkIdentity _networkIdentity;
        private float _cooldown;

        private void Start()
        {
            _networkIdentity = GetComponent<NetworkIdentity>();
        }
        
        private void Update()
        {
            if (_networkIdentity.hasAuthority && Input.GetButton("Fire1") && _cooldown <= 0)
            {
                _cooldown = Period;
                Shoot();
            }
            _cooldown -= Time.deltaTime;
        }

        private void Shoot()
        {
            var position = Camera.main.WorldToViewportPoint(FirePoint.position);
            var mousePos = (Vector2) Camera.main.ScreenToViewportPoint(Input.mousePosition + Vector3.forward);
            var angle = Mathf.Atan2(position.y - mousePos.y, position.x - mousePos.x) * Mathf.Rad2Deg;
            var bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, angle) * new Vector2(-3, 0);
            CmdSpawnBullet(bullet);
        }

        [Command]
        private void CmdSpawnBullet(GameObject bullet)
        {
            NetworkServer.Spawn(bullet);
        }
    }
}
