using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController character;
    public float speed = 12f;
    public float gravity = -9.8f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;
    float timeBetweenJumps = 0f;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            print("hello");
            velocity.y = -2f;
        }
        
        jump();
        MovePlayer();
    }


    public void MovePlayer()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        character.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);

    }

    void jump()
    {
        timeBetweenJumps += Time.deltaTime;
        print("time" + timeBetweenJumps);
        if (timeBetweenJumps >=0.8f)
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                timeBetweenJumps = 0f;
            }
            
        }
        
    }

}
