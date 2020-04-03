using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2d : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 10f;
    public bool isGrounded = false;
    public bool doubleJump = true;
    private float moveInput;
    public Animator animator;
    private Rigidbody2D rb;


    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Jump();

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetBool("Grounded", isGrounded);

        Vector3 characterScale = transform.localScale;

        if(Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -0.625f;
        } else if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 0.625f;
        }
        transform.localScale = characterScale;

        if (!isGrounded)
            moveSpeed = 8f;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            SoundManagerScript.PlaySound("jump");
            doubleJump = false;
        }
        if(isGrounded == true)
        {
            doubleJump = true;
        }
    }
    
}
