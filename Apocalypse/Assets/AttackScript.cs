using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    public GameObject projectile;
    public Transform player;
    public Transform generatePoint;

    public bool stop = false;

    void Update()
    {
        transform.LookAt(player);
        Attack();
    }
    private void Attack()
    {
        if (!stop)
        {
            Rigidbody rb = Instantiate(projectile, generatePoint.position, transform.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 6f, ForceMode.Impulse);
            //Destroy(rb.gameObject, 1f);
            stop = true;
        }
    }
}
