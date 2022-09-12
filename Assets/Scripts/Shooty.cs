using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooty : NiceGhosts
{
    public GameObject hearts;
    public override void ApplySkill()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(hearts, transform.position + Vector3.right, Quaternion.identity);
        }
    }

    
}
