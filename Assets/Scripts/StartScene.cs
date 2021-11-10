using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            SceneManager.LoadScene(1);
        }
    }
}
