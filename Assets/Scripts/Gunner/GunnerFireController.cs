using UnityEngine;
using UnityEngine.Networking;

namespace Gunner
{
    public class GunnerFireController : NetworkBehaviour
    {
        private Camera _camera;
        private float _cooldown;
        private Transform _firepoint;

        private NetworkIdentity _networkIdentity;
        public GameObject BulletPrefab;
        public float Period;

        private void Start()
        {
            _camera = Camera.main;
            _networkIdentity = GetComponent<NetworkIdentity>();
            _firepoint = transform.Find("FirePoint");
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
            var firePoint = _firepoint.position;
            
            var mousePos = (Vector2) _camera.ScreenToWorldPoint(Input.mousePosition);
            var angle = Mathf.Atan2(firePoint.y - mousePos.y, firePoint.x - mousePos.x) * Mathf.Rad2Deg;

            var bullet = Instantiate(BulletPrefab, firePoint, _firepoint.rotation);
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