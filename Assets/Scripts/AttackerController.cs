using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class AttackerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;

    private Rigidbody2D rb;

    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

     //   rb.position = new Vector3
       // (
         //   Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
           // 0.0f,
            //Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax)
   //     );

 
    }
}