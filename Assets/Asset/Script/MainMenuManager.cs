﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
