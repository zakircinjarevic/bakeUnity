using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject player;
    void Start ()
    {
        player = GameObject.Find("player");
    }
    public bool canPlaySound = true;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground" || collision.collider.tag == "block")
        {
            player.GetComponent<Move2d>().isGrounded = true;
        }
        if (collision.collider.tag == "check")
        {
            if(canPlaySound)
            {
                SoundManagerScript.PlaySound("enemy-death");
                canPlaySound = false;
                Invoke("EnableSound", 0.1f);
            }
            Debug.Log("lmao");
            player.GetComponent<Rigidbody2D>().velocity = Vector2.up * (player.GetComponent<Move2d>().jumpForce - 2f);
        }
        
    }
    void Update ()
    {
        if (player.GetComponent<Rigidbody2D>().velocity.y != 0)
        {
            player.GetComponent<Move2d>().isGrounded = false;
        } else
        {
            player.GetComponent<Move2d>().isGrounded = true;
        }
    }
    private void EnableSound()
    {
        canPlaySound = true;
    }
}
