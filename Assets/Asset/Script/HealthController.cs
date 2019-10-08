using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    [SerializeField] private float health = 100.0f;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public void ApplyDamage(float damage)
    {
        Debug.Log("Damaged!" + damage);
        health -= damage;

        if(health <= 0)
        {
            Debug.Log("Target Destroyed!");
           // GetComponent<Enemy>().enabled = false;
            anim.SetBool("isDead", true);
            Destroy(gameObject, 3.0f);
        }
    }
}
