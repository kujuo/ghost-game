using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Player player = col.GetComponent<Player>();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
