using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RigidbodyFirstPersonController m_player = other.GetComponent<RigidbodyFirstPersonController>();
            if (m_player != null)
            {
                Debug.Log("You reached the goal!");
                SceneManager.LoadScene("mainMenu");
            }
        }
    }
}
