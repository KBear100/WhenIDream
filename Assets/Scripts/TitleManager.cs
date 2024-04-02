using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("BabyDream");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
