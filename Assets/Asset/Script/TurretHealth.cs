using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : MonoBehaviour {

    [SerializeField] private float health = 140.0f;

    void Start()
    {
        
    }

    public void ApplyDamage(float damage)
    {
        Debug.Log("Damaged!" + damage);
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Target Destroyed!");
            // GetComponent<Enemy>().enabled = false;
            Destroy(this.gameObject);
        }
    }
}
