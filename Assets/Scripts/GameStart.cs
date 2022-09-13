using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class GameStart : MonoBehaviour
{
    [SerializeField] private TextWriter textWriter;
    private TextMeshProUGUI messageText;
    // Start is called before the first frame update
    void Awake()
    {
        messageText = transform.Find("message").Find("messageText").GetComponent<TextMeshProUGUI>();
    
    }

    // Update is called once per frame
    void Start()
    {
        messageText.transform.TransformPoint(new Vector3(-406.1f, -203.6f, 0));
        messageText.text = "Oh no we brought back the evil ghosts!                     ";
        textWriter.AddWriter(messageText, "Oh no we brought back the evil ghosts!                     ", 0.1f);
    }
}
