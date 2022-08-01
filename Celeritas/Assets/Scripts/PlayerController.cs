using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isGrounded = false;
    int DoubleJump = 2;
    Rigidbody2D rb;        
    public float jumpForce = 6;     
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            isGrounded = true;
            DoubleJump = 2;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ground")
        {
            isGrounded = false;
            
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DoubleJump > 0 )
        {
            rb.velocity = Vector2.up * jumpForce;
            DoubleJump--;

        }
       
            
    }

}

