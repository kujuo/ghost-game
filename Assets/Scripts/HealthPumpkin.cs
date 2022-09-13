using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPumpkin : MonoBehaviour
{
    private GameObject player;
    private Player pScript;
    private float playerHP;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("player");
        pScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHP = pScript.hp;
        if(playerHP <= 60)
        {
            sr.color = Color.yellow;
        }
        if(playerHP <= 40)
        {
            sr.color = Color.red;
        }
    }
}
