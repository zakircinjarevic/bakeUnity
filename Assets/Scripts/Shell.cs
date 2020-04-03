using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public bool moveLeft = true;
    public float speed = 0f;
    public bool collidedWithBlock = false;
    public ParticleSystem particles;
    public bool firstCollision = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }
    void Update()
    {
        if (moveLeft)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CheckCollider(collision.collider.tag);
        if (collision.collider.tag == "block")
        {
            collidedWithBlock = true;
            if (collidedWithBlock)
            {
                Debug.Log("w block");
                SoundManagerScript.PlaySound("enemy-death");
                moveLeft = !moveLeft;
                collidedWithBlock = false;
                Invoke("DisableCollidedWithBlock", 0.1f);
            }

        }
        else if (collision.collider.tag == "shell")
        {
            if(collision.collider.GetComponent<Shell>().speed > 0f && speed == 0f)
            {
                gameObject.SetActive(false);
                Globals.enemyPosition = gameObject.transform.position;
                particles.transform.position = Globals.enemyPosition;
                Globals.enemyParticleActive = true;
                Invoke("StopEnemyParticles", 0.1f);
                SoundManagerScript.PlaySound("enemy-death");
            }
            else if (collision.collider.GetComponent<Shell>().speed == 0f && speed > 0f)
            {
                collision.collider.gameObject.SetActive(false);
                Globals.enemyPosition = collision.collider.transform.position;
                particles.transform.position = Globals.enemyPosition;
                Globals.enemyParticleActive = true;
                Invoke("StopEnemyParticles", 0.1f);
                SoundManagerScript.PlaySound("enemy-death");
            }
        }

    }
    private void CheckCollider(string tag)
    {
        switch(tag)
        {
            case "groundCheck":
                {
                    PlayersGroundCheckCollided();
                    break;
                }
            case "Player":
                {
                    PlayerCollidedWithShell();
                    break;
                }
        }
    }
    private void PlayersGroundCheckCollided()
    {
        PlayerBounce(player);
        if (firstCollision)
        {
            speed = 0f;
            firstCollision = false;
        }
        else
        {
            if (speed > 0f)
            {
                speed = 0f;
            }
            else
            {
                speed = 8.1f;
            }
        }
        if (player.transform.localScale.x > 0)
        {
            moveLeft = false;
        }
        else
        {
            moveLeft = true;
        }
    }
    private void PlayerCollidedWithShell()
    {
        Debug.Log("coll w player");
        Globals.justCollided = true;
        Invoke("DisableJustCollided", 0.01f);
        if (speed > 0f)
        {
            speed = 0f;
        }
        else
        {
            speed = 8.1f;
        }

        if (player.transform.localScale.x > 0)
        {
            moveLeft = false;
        }
        else
        {
            moveLeft = true;
        }
    }
    private void PlayerBounce(GameObject player)
    {
       player.GetComponent<Rigidbody2D>().velocity = Vector2.up * (player.GetComponent<Move2d>().jumpForce - 2f);
    }
    // INVOKED FUNCTIONS
    private void DisableJustCollided()
    {
        Globals.justCollided = false;
    }
    private void DisableCollidedWithBlock()
    {
        collidedWithBlock = true;
    }
    private void StopEnemyParticles()
    {
        Globals.enemyParticleActive = false;
    }

}
