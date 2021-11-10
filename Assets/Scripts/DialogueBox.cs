using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private Text titleText;
    [SerializeField] private Text fullText;
    [SerializeField] private float endHeight;
    [SerializeField] private float upTime;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!spriteRenderer.enabled) spriteRenderer.enabled = true;
        transform.DOMoveY(transform.position.y + endHeight, upTime).SetEase(Ease.OutCubic).SetLoops(2, LoopType.Yoyo);
        
    }
    
}
