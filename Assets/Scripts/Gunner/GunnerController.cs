using UnityEngine;
using UnityEngine.Networking;

namespace Gunner
{
    public class GunnerController : MonoBehaviour
    {
        private NetworkIdentity _networkIdentity;
        private Rigidbody2D rb;

        public float speed;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            _networkIdentity = GetComponent<NetworkIdentity>();
        }

        private void FixedUpdate()
        {
            if (!_networkIdentity.hasAuthority) return;
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");

            var movement = new Vector3(moveHorizontal, moveVertical);
            rb.velocity = movement * speed;
        }
    }
}