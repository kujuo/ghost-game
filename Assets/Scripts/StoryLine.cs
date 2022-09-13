using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryLine : MonoBehaviour
{
    public GameObject gameStart;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gameStart, new Vector3(-402.31f, -204.01f, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    Destroy(gameObject);
        //}
    }
}
