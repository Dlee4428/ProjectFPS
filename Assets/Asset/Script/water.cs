using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class water : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RigidbodyFirstPersonController m_player = other.GetComponent<RigidbodyFirstPersonController>();
            if (m_player != null)
            {
                m_player.movementSettings.ForwardSpeed = 3.0f;   // Speed when walking forward
                m_player.movementSettings.BackwardSpeed = 2.0f;
                m_player.movementSettings.StrafeSpeed = 1.0f;
                m_player.movementSettings.RunMultiplier = 1.5f;
                Debug.Log("Water slowed down");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RigidbodyFirstPersonController m_player = other.GetComponent<RigidbodyFirstPersonController>();
            if (m_player != null)
            {
                m_player.movementSettings.ForwardSpeed = 12.0f;   // Speed when walking forward
                m_player.movementSettings.BackwardSpeed = 8.0f;
                m_player.movementSettings.StrafeSpeed = 4.0f;
                m_player.movementSettings.RunMultiplier = 2.0f;
                Debug.Log("Back From Track");
            }
        }
    }
}
