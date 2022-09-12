using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEvil : EvilGhost
{
    public Sprite[] idleFrames;
    public float animateSpeed;
    public GameObject player;
    public float speed;

    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(idleAnimate());
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        Vector3 move = Vector3.MoveTowards(transform.position, player.transform.position, step);
        move.y += Random.Range(-step, step);
        transform.position = move;
        //print(transform.position);
        //print(player.transform.position);
        //transform.position = Vector3.Lerp(transform.position, player.transform.position, .1f);
    }

    IEnumerator idleAnimate()
    {
        int frame = 0;
        while (true)
        {
            if (frame >= idleFrames.Length) frame = 0;
            sr.sprite = idleFrames[frame];
            frame++;
            yield return new WaitForSeconds(animateSpeed);
        }
    }
}
