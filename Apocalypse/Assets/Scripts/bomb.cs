using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    
    public GameObject explosion;
    int damage = 10;
    AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain" || collision.gameObject.name == "player")
        {

            GameObject effect = Instantiate(explosion, transform.position, Quaternion.LookRotation(Vector3.up));
            
            Destroy(effect, 1f);
            Destroy(gameObject);
            audioSource.Play();
        }
        Fighter fighter = collision.gameObject.GetComponent<Fighter>();
        if(fighter != null && collision.gameObject.name == "player")
        {
            fighter.TakeDamage(damage);
        }
    }
}
