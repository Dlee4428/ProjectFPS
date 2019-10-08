using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MushroomScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RigidbodyFirstPersonController m_player = other.GetComponent<RigidbodyFirstPersonController>();
            if (m_player != null)
            {
                m_player.movementSettings.ForwardSpeed = 20.0f;   // Speed when walking forward
                m_player.movementSettings.BackwardSpeed = 20.0f;
                m_player.movementSettings.StrafeSpeed = 20.0f;
                m_player.movementSettings.RunMultiplier = 1.5f;
                Debug.Log("Speed UP!");

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
