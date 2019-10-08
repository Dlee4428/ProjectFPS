using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AK47 : MonoBehaviour {

    private Animator anim;
    private AudioSource audioSource;

    public float range = 100.0f;
    public int bulletsPerMag = 30;
    public int bulletsLeft = 200;

    public int currentBullets;
    public ParticleSystem pS;

    public Text ammoText;

    public Transform shootPoint;
    public GameObject hitParticles;
    public GameObject bulletImpact;

    public ParticleSystem muzzleFlash;
    public AudioClip shootSound;

    public float fireRate = 0.1f;
    public float damage = 20.0f;
    
    float fireTimer;

    private bool isReloading;
    private bool isPlaying;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        currentBullets = bulletsPerMag;
	}
	
	// Update is called once per frame
	void Update () {



        if (Input.GetButton("Fire1"))
        {
            if (currentBullets > 0)
                Fire(); //Execute fire function if we press/hold left mouse
            else if (bulletsLeft > 0)
                DoReload();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentBullets < bulletsPerMag && bulletsLeft > 0)
                DoReload();
        }

        if (fireTimer < fireRate)
            fireTimer += Time.deltaTime; //Add into time counter

        UpdateAmmoText();
	}

    void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        isReloading = info.IsName("Reload");
        //if (info.IsName("Fire")) anim.SetBool("Fire", false);
    }



    private void Fire()
    {
        if (fireTimer < fireRate || currentBullets <= 0 || isReloading)
            return;

        RaycastHit hit;

        if(Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name + " found!");

            GameObject hitParticleEffect = Instantiate(hitParticles, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            GameObject bulletHole = Instantiate(bulletImpact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));

            Destroy(hitParticleEffect, 1);
            Destroy(bulletHole, 2);

            if (hit.transform.GetComponent<HealthController>())
            {
                hit.transform.GetComponent<HealthController>().ApplyDamage(damage);
            }

            if (hit.transform.GetComponent<TurretHealth>())
            {
                hit.transform.GetComponent<TurretHealth>().ApplyDamage(damage);
            }
        }

        anim.CrossFadeInFixedTime("Fire", 0.01f); //Play the fire animation
        PlayerShootSound(); //Play the shooting sound effect
        currentBullets--; //Deduct one bullet
        muzzleFlash.Play();
        UpdateAmmoText();
        fireTimer = 0.0f; //Reset fire timer
    }

    public void Reload()
    {
        if (bulletsLeft <= 0)
            return;

        int bulletsToLoad = bulletsPerMag - currentBullets;
        int bulletsToDeduct = (bulletsLeft >= bulletsToLoad) ? bulletsToLoad : bulletsLeft;

        bulletsLeft -= bulletsToDeduct;
        currentBullets += bulletsToDeduct;
    }

    private void DoReload()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        if (isReloading)
            return;

        anim.CrossFadeInFixedTime("Reload", 0.01f);
    }

    public void PlayerShootSound()
    {
        audioSource.PlayOneShot(shootSound);
      //  _AudioSource.clip = shootSound;
      //  _AudioSource.Play();
    }

    private void UpdateAmmoText()
    {
        //                   30                     120
        ammoText.text = currentBullets + " / " + bulletsLeft;
    }
}
