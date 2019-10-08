using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

    public GameObject m_gameOverScreen;

    public void GameOverScreen()
    {
        m_gameOverScreen.SetActive(true);
        SceneManager.LoadScene("mainMenu");
    }
}
