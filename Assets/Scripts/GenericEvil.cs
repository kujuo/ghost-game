using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEvil : EvilGhost
{
    public Sprite[] idleFrames;
    public Sprite[] rightFrames;
    public float animateSpeed = 0.5f;
    public GameObject player;
    public float speed = 0.5f;
    public float activeDistance;
    private bool active;

    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(animate(idleFrames));
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < activeDistance)
            {
                active = true;
                StopAllCoroutines();
                sr.flipX = false;
                StartCoroutine(animate(rightFrames));
            }

            else return;
        }


        var step = speed * Time.deltaTime; // calculate distance to move
        Vector3 move = Vector3.MoveTowards(transform.position, player.transform.position, step);
        transform.position = move;

        Vector3 sub = player.transform.position - move;
        if (sub.x > 0 && sr.flipX != false)
        {
            sr.flipX = false;
            StopAllCoroutines();
            StartCoroutine(animate(rightFrames));
        }
        else if (sub.x < 0 && sr.flipX == false)
        {
            sr.flipX = true;
            StopCoroutine("animate");
            StartCoroutine(animate(rightFrames));
        }
    }

    IEnumerator animate(Sprite[] frames)
    {
        int frame = 0;
        while (true)
        {
            if (frame >= frames.Length) frame = 0;
            sr.sprite = frames[frame];
            frame++;
            yield return new WaitForSeconds(animateSpeed);
        }
    }


}
