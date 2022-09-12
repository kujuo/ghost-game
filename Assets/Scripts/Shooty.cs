using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Shooty : NiceGhosts
{
    public GameObject hearts;
    public Sprite[] attackSprites;
    public float framesPerSecond;
    private float timer = 1;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public override void ApplySkill()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(Shoot());
        }
    }


    private IEnumerator Shoot()
    {
        for (int i = 0; i < attackSprites.Length; i++)
        {
            sr.sprite = attackSprites[i];
            timer = 1 / framesPerSecond;
            yield return new WaitForSeconds(timer);
        }
        Instantiate(hearts, transform.position + Vector3.right, Quaternion.identity);
    }

}