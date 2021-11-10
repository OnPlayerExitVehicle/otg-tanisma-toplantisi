using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBase : MonoBehaviour
{
    public bool finished { get; protected set; }
    public string input;
    protected IEnumerator WriteText(Text textHolder,Font textFont,float delay, float delayBetweenLines)
    {
        //textHolder.color = textColor;
        //textHolder.font = textFont;
        if(textHolder.font == null) Debug.Log("31");
        //Tek tek yaz�y� ekrana yazmay� sa�layan fonksiyon.
        
        for(int i = 0; i < input.Length; i++)
        {
            textHolder.text += input[i];

            yield return new WaitForSeconds(delay);
        }
        //yield return new WaitForSeconds(delayBetweenLines);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Joystick1Button0));
        finished = true;
    }
}
