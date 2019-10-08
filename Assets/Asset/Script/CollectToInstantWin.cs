using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectToInstantWin : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth m_player = other.GetComponent<PlayerHealth>();
            if (m_player != null)
            {
                Debug.Log("You Collect MasterKey! You escaped from the Game!");
                Destroy(this.gameObject);
                SceneManager.LoadScene("mainMenu");
            }
        }
    }
}
