using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int maxHealth = 50;
    public int currHealth;
    public GameObject explosion;

    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        currHealth -= amount;
        if (currHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameObject effect = Instantiate(explosion, transform.position, Quaternion.LookRotation(Vector3.up));
        Destroy(effect, 1f);
        Destroy(gameObject);
        
    }
}
