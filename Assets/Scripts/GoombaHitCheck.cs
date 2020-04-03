using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaHitCheck : MonoBehaviour
{
    public GameObject player;
    public ParticleSystem particles;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "groundCheck")
        {
            transform.parent.gameObject.GetComponent<EnemyMovement>().speed = 0f;
            Globals.enemyPosition = transform.parent.gameObject.transform.position;
            particles.transform.position = Globals.enemyPosition;
            Globals.enemyParticleActive = true;
            Invoke("StopEnemyParticles", 0.1f);
            transform.parent.gameObject.SetActive(false);
        }
    }
    private void StopEnemyParticles()
    {
        Globals.enemyParticleActive = false;
    }
}
