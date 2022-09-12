using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb2D;
    public float speed = 3;
    public float jumpForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = rb2D.velocity;
        float inputX = Input.GetAxisRaw("Horizontal");
        vel.x = speed * inputX;
        rb2D.velocity = vel;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        /*
        Vector3 mov = new Vector3(inputX, vel.y, 0);

        if (mov.magnitude != 0)
        {
            mov.Normalize();
        }
        rb2D.velocity = mov * speed;
        */

        


    }
}
