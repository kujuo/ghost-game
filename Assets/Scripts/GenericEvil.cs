using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEvil : EvilGhost
{
    public Sprite[] idleFrames;
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
        StartCoroutine(idleAnimate());
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < activeDistance) active = true;
            else return;
        }

        var step = speed * Time.deltaTime; // calculate distance to move
        Vector3 move = Vector3.MoveTowards(transform.position, player.transform.position, step);
        move.y += Random.Range(-step, step);
        transform.position = move;
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
