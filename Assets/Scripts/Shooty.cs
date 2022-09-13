using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Shooty : NiceGhosts
{
    public GameObject hearts;
    public Sprite[] attackSprites;
    public float framesPerSecond;
    public float timer = 1f;
    SpriteRenderer sr;
    public float currentCharge = 100f;
    public float chargeIncrease = 10f;
    public float chargeDecrease = 20f;
    public float coolDownTime = 1f;
    public Sprite leftTurnShooty;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        shootyTurn();
    }

    public override void ApplySkill()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = transform.position + new Vector3(10, 0, 0) * 0.5f;
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
        transform.position = transform.position + new Vector3(-10, 0, 0) * 0.5f;
    }

    private IEnumerator coolDown()
    {
        if (currentCharge < 100) {

            yield return new WaitForSeconds(coolDownTime);
            currentCharge += chargeIncrease;
        }
    }

   private void shootyTurn()
    {
        SpriteRenderer parentSR = GetComponentInParent<SpriteRenderer>();
        if (parentSR.flipX == true)
        {
            sr.flipX = false;
            sr.sprite = leftTurnShooty;
        }
        else
            sr.flipX = true;
            sr.sprite = leftTurnShooty;
    }
}