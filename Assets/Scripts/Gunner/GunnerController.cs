using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Gunner
{
    [Serializable]
    public class Boundary
    {
        public float xMin, xMax, yMin, yMax;
    }

    public class GunnerController : MonoBehaviour
    {
        public Boundary boundary;

        private Rigidbody2D rb;
        private NetworkIdentity _networkIdentity;

        public float speed;
        public float tilt;

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

            rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
                0.0f
            );
        }
    }
}