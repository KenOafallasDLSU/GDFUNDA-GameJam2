using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnloadGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnloadScene();
    }

    public void UnloadScene()
    {
        Debug.Log("UNLOAD GAME SCENE");
        SceneManager.UnloadSceneAsync("Game");
    }
}
