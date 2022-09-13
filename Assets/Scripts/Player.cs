using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb2D;
    private SpriteRenderer sr;

    public float speed = 3;
    public float jumpForce = 3;

    public float hp = 100;

    public LayerMask groundMask;

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
    bool hurt;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        hp = 100;
        Debug.Log("Started! Current health:" + hp);

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
        hurt = false;
    }

    // Update is called once per frame
    void Update()
    {
        //left-right movement
        Vector3 vel = rb2D.velocity;
        float inputX = Input.GetAxisRaw("Horizontal");
        vel.x = speed * inputX;
        rb2D.velocity = vel;

        //face in direction
        if (inputX >= 0) sr.flipX = false;
        if (inputX < 0) sr.flipX = true;

        //left-right animation
        if (Mathf.Abs(inputX) > 0) WalkAnimation();
        else if (!hurt) IdleAnimation();

        //jump (but no double-jumping)
        bool isGrounded = CheckGrounded();
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //check health
        if (hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(hp <= 20)
        {
            GameObject bkgrd = GameObject.Find("background");
            SpriteRenderer bkgrdsr = bkgrd.GetComponent<SpriteRenderer>();
            bkgrdsr.color = new Color(1, 0, 0);
        }

    }


    // check if grounded
    private bool CheckGrounded()
    {
        bool isGrounded;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, 1f, groundMask);
        // Debug.DrawLine(transform.position, transform.position + Vector3.down * 1f, Color.red);
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        return isGrounded;
    }

    // on triggers

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hurt = true;
        hp -= 20;
        Debug.Log("I lost health. Current health: " + hp);
        sr.sprite = frames[hurtFrame];

        // jump backwards
        Vector3 dir = collision.transform.position - transform.position;
        if (dir.x >= 0) transform.position += Vector3.left;
        else transform.position += Vector3.right;
    }
    
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        hurt = false;
        sr.sprite = frames[firstIdleFrame];
    }
    

    //animations

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
