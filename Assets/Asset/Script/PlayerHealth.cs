using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] public float health = 100.0f;

    public Text healthText;
    public HUD m_hud;
    public GameOverManager gManager;
    public void ApplyDamage(float damage)
    {
        Debug.Log("Damaged!" + damage);
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Target Destroyed!");
            Die();
        }
    }

    public void Die()
    {
        m_hud.GameOverScreen();
       // GetComponent<RigidbodyFirstPersonController>().enabled = false;
       // GetComponent<AK47>().enabled = false;
    }

    void Start()
    {
        UpdateHealthText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Debug.Log("Game paused");
                Time.timeScale = 0;
            }
            else
            {
                Debug.Log("Game Resumed");
                Time.timeScale = 1;
            }
        }

        UpdateHealthText();
        //Turn GameOverScreen
        if (Input.GetKey(KeyCode.Alpha1))
        {
            health = 0.0f;
            Debug.Log("InstantDeath triggered!");
            Die();
        }
        //Quit the game
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Application.Quit();
        }
    }

    private void UpdateHealthText()
    {
       
        healthText.text = health + " ";
    }
}
