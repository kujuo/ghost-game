using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb2D;
    private SpriteRenderer sr;

    public float speed = 3;
    public float jumpForce = 3;

    //animation variables
    public Sprite[] frames;
    public float fps = 20;
    private float timer;

    private int firstRunFrame;
    private int lastRunFrame;
    private int currRunFrame;

    private int firstIdleFrame;
    private int lastIdleFrame;
    private int currIdleFrame;
    private float idleTimer;

    private int hurtFrame;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        //animation
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        timer = 1 / fps;
        sr.sprite = frames[0];

        firstRunFrame = 4;
        lastRunFrame = 9;
        currRunFrame = firstRunFrame;

        firstIdleFrame = 0;
        lastIdleFrame = 3;
        currIdleFrame = 0;
        idleTimer = 5 / fps;

        hurtFrame = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //left-right movement
        Vector3 vel = rb2D.velocity;
        float inputX = Input.GetAxisRaw("Horizontal");
        vel.x = speed * inputX;
        rb2D.velocity = vel;

        //left-right animation
        if (Mathf.Abs(inputX) > 0) WalkAnimation();
        else IdleAnimation();

        //jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && vel.y == 0)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //face in direction
        if (inputX >= 0) sr.flipX = false;
        if (inputX < 0) sr.flipX = true;




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I lost health.");
        sr.sprite = frames[hurtFrame];
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        sr.sprite = frames[firstIdleFrame];
    }
    

    void WalkAnimation()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            sr.sprite = frames[currRunFrame];
            currRunFrame++;
            if (currRunFrame > lastRunFrame) currRunFrame = firstRunFrame;
            timer = 1 / fps;
        }
    }

    
    void IdleAnimation()
    {
        idleTimer -= Time.deltaTime;
        if (idleTimer <= 0)
        {
            sr.sprite = frames[currIdleFrame];
            currIdleFrame++;
            if (currIdleFrame > lastIdleFrame) currIdleFrame = firstIdleFrame;
            idleTimer = 5 / fps;
        }
    }
    
}
