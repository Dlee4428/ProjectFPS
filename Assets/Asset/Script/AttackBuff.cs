using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuff : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AK47 m_ak47 = other.GetComponentInChildren<AK47>();
            if (m_ak47 != null)
            {
                Debug.Log("100 Ammo!");
                m_ak47.bulletsLeft += 100;
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
