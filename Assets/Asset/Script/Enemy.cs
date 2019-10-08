using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform player;
    Animator anim;

    string state = "patrol";
    public GameObject[] waypoints;
    int currentWP = 0;
    float rotSpeed = 1.5f;
    float speed = 3.0f;
    float accuracyWP = 5.0f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = player.position - this.transform.position;
        direction.y = 0;
        float angle = Vector3.Angle(direction, this.transform.forward);

        anim.SetBool("isIdle", false);
        if(state == "patrol" && waypoints.Length > 0)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
            {
                currentWP++;
                if (currentWP >= waypoints.Length)
                {
                    currentWP = 0;
                }
            }

            //Rotate toward waypoint
            direction = waypoints[currentWP].transform.position - transform.position;
            this.transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            this.transform.Translate(0, 0, Time.deltaTime * speed);

        }


        if(Vector3.Distance(player.position, this.transform.position) < 10 && (angle < 30 || state == "pursuing"))
        {
            state = "pursuing";
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

            anim.SetBool("isIdle", false);
            if(direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, Time.deltaTime * speed);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            state = "patrol";
        }

	}
}
