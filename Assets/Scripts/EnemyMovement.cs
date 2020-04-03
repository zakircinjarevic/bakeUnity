using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool moveLeft = true;
    public bool canCollide = true;
    public float speed = 2f;
    private Rigidbody2D rb;
    private Vector3 spriteScale;
    public ParticleSystem particles;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteScale = transform.localScale;
    }
    // MOVEMENT & FLIPPING
    void Update()
    {
        if (moveLeft)
        {
            spriteScale.x = -0.625f;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = spriteScale;
        }
        else
        {
            spriteScale.x = 0.625f;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = spriteScale;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // HANDLING INSTANTANEOUS COLLISIONS AND BOUNCING AGAINST WALLS
        if (collision.collider.tag != "ground" && collision.collider.tag != "Player" && collision.collider.tag != "shell")
        {
            if (canCollide == true)
            {
                moveLeft = !moveLeft;
                canCollide = false;
                Invoke("AllowCollision", 0.05f); 
            }
        }
        // DESTROYING HOSTILES HIT BY MOVING SHELL
        else if (collision.collider.tag == "shell" && collision.collider.GetComponent<Shell>().speed > 5f)
        {
            gameObject.SetActive(false);
            Globals.enemyPosition = gameObject.transform.position;
            particles.transform.position = Globals.enemyPosition;
            Globals.enemyParticleActive = true;
            Invoke("StopEnemyParticles", 0.1f);
            SoundManagerScript.PlaySound("enemy-death");
        }
        // BOUNCING HOSTILES AGAINST MOTIONLESS SHELL
        else if (collision.collider.tag == "shell" && collision.collider.GetComponent<Shell>().speed == 0f)
        {
            if (canCollide == true)
            {
                moveLeft = !moveLeft;
                canCollide = false;
                Invoke("AllowCollision", 0.05f);
            }
        }
        else if (collision.collider.tag == "groundCheck")
        {
            HitByPlayer();
        }
    }
    private void HitByPlayer()
    {
        gameObject.SetActive(false);
        Globals.enemyPosition = gameObject.transform.position;
        particles.transform.position = Globals.enemyPosition;
        Globals.enemyParticleActive = true;
        Invoke("StopEnemyParticles", 0.1f);
    }
    // INVOKED FUNCTIONS
    private void AllowCollision ()
    {
        canCollide = true;
    }
    private void StopEnemyParticles()
    {
        Globals.enemyParticleActive = false;
    }
}
