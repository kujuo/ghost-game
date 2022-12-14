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
    private float currentCharge = 100;
    private float chargeIncrease = 10;
    private float chargeDecrease = 20;
    private float coolDownTime = 1;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public override void ApplySkill()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = transform.position + new Vector3(3, 0, 0) * 0.5f;
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
        currentCharge -= chargeDecrease;
        transform.position = transform.position + new Vector3(-3, 0, 0) * 0.5f;
    }

    private IEnumerator coolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        currentCharge += chargeIncrease;
    }

}