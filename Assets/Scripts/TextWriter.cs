using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class TextWriter : MonoBehaviour
{
    public GameObject obj;
    private TextWriterSingle textWriterSingle;

    public void AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter)
    {
        textWriterSingle = new TextWriterSingle(obj, uiText, textToWrite, timePerCharacter);
    }

    private void Update()
    {
        if (textWriterSingle != null)
        {
            textWriterSingle.Update();
        }
        
    }

    public class TextWriterSingle
    {
        public GameObject obj;
        private TextMeshProUGUI uiText;
        private string textToWrite;
        private int characterIndex;
        private float timePerCharacter;
        private float timer;

        public TextWriterSingle(GameObject obj, TextMeshProUGUI uiText, string textToWrite, float timePerCharacter)
        {
            this.obj = obj;
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerCharacter = timePerCharacter;
            characterIndex = 0;
        }

        public void Update()
        {
            if (uiText != null)
            {
                
                timer -= Time.deltaTime;
                if (timer <= 0f)
                {
                    timer += timePerCharacter;
                    characterIndex++;
                    Vector3 vector = new Vector3(0, -3, 0);
                    uiText.transform.TransformPoint(obj.transform.position);
                    uiText.transform.position = obj.transform.position;
                    uiText.text = textToWrite.Substring(0, characterIndex);
                    if (characterIndex >= textToWrite.Length)
                    {
                        uiText.text = "";
                        uiText = null;
                        return;
                    }
                }
            }

        }
    }

}
