using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonMouseDown : MonoBehaviour
{
    void OnMouseDown()
    {
        Debug.Log("APP QUIT");
        Application.Quit();
    }
}
