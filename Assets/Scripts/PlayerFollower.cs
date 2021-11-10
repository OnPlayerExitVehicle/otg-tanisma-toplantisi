using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private GameObject followObject;
    [SerializeField] private float sensitivity = 0.8f;
    [SerializeField] private float down;
    
    void Update()
    {

        float tempX = Mathf.Lerp(transform.position.x, followObject.transform.position.x, sensitivity);
        float tempY = Mathf.Lerp(transform.position.y,
            followObject.transform.position.y - (GlobalData.IsDialogueOpen ? down : 0.0f), sensitivity);
        transform.position = new Vector3(tempX, tempY, transform.position.z);
    }
}
