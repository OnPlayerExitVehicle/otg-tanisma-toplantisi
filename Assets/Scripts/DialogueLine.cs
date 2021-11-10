using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace DialogueBaseClass {
    public class DialogueLine : DialogueBase
    {
        //Unity aray�z�nden her �eyi ayarlayabilirsin.
        private Text textHolder;
        [Header ("Text Customization")]
        //[SerializeField] public string input;
        [SerializeField] Color textColor;
        [SerializeField] Font textFont;
        [Header ("Text Delay")]
        [SerializeField] float delay;
        [SerializeField] float delayBetweenLines;
        [Header("Sound Properties")]
        [SerializeField] AudioClip sound;

        private void Awake()
        {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            //SoundManager.instance.PlaySound(sound);
        }
        private void Start()
        {
            
        }

        private void OnEnable()
        {
            finished = false;
            textHolder.text = String.Empty;
            StartCoroutine(WriteText(textHolder, textFont, delay, delayBetweenLines));
            
        }

        public void StartWriting()
        {

        }
    }
}
