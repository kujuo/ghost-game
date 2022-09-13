using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EvilGhost : MonoBehaviour
{
    public float health;
    void loseHealth(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            onDeath();
        }
    }

    public abstract void onDeath();
}
