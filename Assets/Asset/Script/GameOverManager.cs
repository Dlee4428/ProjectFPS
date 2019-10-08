using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    public PlayerHealth pHealth;
    public float restartDelay = 5.0f;

    private Animator m_animator;

    public void Awake()
    {
        m_animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (pHealth.health == 0)
        {
            SetTrigger();
        }
    }

    void SetTrigger()
    {
        m_animator.SetTrigger("GameOver");
        SceneManager.LoadScene("mainMenu");
    }
}
