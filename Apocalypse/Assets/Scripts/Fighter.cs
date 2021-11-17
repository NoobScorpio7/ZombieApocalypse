using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int damage = 10;
    public Camera cam;
    public float range = 70f;
    public GameObject bulletEffect;
    AudioSource audioSource;
    public int maxHealth = 100;
    public int CurrHealth;
    public HealthBar healthBar;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CurrHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Input.GetButtonDown("Fire1"))
        {
            audioSource.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                Target target = hit.transform.GetComponent<Target>();
                Debug.Log(hit.transform.name);
                GameObject effect = Instantiate(bulletEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(effect, 1f);
                if(target != null)
                {
                    target.TakeDamage(damage);
                }
                
            }

        }
    }

    public void TakeDamage(int Damage)
    {
        CurrHealth -= damage;
        healthBar.SetHealth(CurrHealth);
    }
}
