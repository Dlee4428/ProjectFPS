using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth m_player = other.GetComponent<PlayerHealth>();
            if (m_player != null)
            {
                Debug.Log("Health Pack! 50 health restored");
                m_player.health += 50.0f;
                Destroy(this.gameObject);
            }
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
