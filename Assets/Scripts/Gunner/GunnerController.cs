using System;
using UnityEngine;

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
        public float speed;
        public float tilt;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");

            var movement = new Vector3(moveHorizontal, moveVertical);
            rb.velocity = movement * speed;

            //   rb.position = new Vector3
            // (
            //   Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            // 0.0f,
            //Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax)
            //     );
        }
    }
}
