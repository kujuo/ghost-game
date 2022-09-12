using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NiceGhosts : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        transform.SetParent(player.transform);
        transform.position = transform.position + new Vector3(-5, 1, 0) * 0.5f;
    }
    public abstract void ApplySkill();

    private void Update()
    {
        ApplySkill();
    }
}
