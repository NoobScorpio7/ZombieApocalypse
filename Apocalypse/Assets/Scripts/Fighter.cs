using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public Camera cam;
    public float range = 70f;
    public GameObject bulletEffect;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
                Debug.Log(hit.transform.name);
                GameObject effect = Instantiate(bulletEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(effect, 1f);
            }

        }
    }
}
