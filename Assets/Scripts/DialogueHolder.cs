using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueBaseClass
{
    public class DialogueHolder : MonoBehaviour
    {
        private DialogueLine dialogueLineTitle;
        private DialogueLine dialogueLineText;

        private Text textTitle;
        private Text textText;
        private void Awake()
        {
            dialogueLineTitle = transform.GetChild(0).GetComponent<DialogueLine>();
            dialogueLineText = transform.GetChild(1).GetComponent<DialogueLine>();

            textTitle = transform.GetChild(0).GetComponent<Text>();
            textText = transform.GetChild(1).GetComponent<Text>();
        }
        
        public void StartDialogue(string title, string text){
            Deactivate(0);
            gameObject.SetActive(true);
            
            //textText.text = String.Empty;
            //textText.text = String.Empty;
            
            dialogueLineTitle.input = title;
            dialogueLineText.input = text;
            StartCoroutine(DialogueSequence());
        }

        private IEnumerator DialogueSequence()
        {
            GlobalData.IsDialogueOpen = true;
            for(int i = 0; i < transform.childCount; i++)
            {
                Deactivate(1);
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
            }
            gameObject.SetActive(false);
            GlobalData.IsDialogueOpen = false;
        }
        private void Deactivate(int number)
        {
            for (int i = number; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
