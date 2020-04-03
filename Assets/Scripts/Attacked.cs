using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacked : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "hostile")
        {
            KillPlayer();
        } else if(collision.collider.tag == "shell" && collision.collider.GetComponent<Shell>().speed > 0f)
        {
            KillPlayer();
        }
    }
    public void KillPlayer ()
    {
        if (!Globals.justCollided)
        {
            gameObject.SetActive(false);
            Invoke("Revive", 0.75f);
            Invoke("StopParticles", 0.25f);
            Globals.particleActive = true;
            Globals.playerPosition = gameObject.transform.position;
            SoundManagerScript.PlaySound("death");
        }
    }
    private void Revive ()
    {
        transform.position = new Vector3(4.5f, 0f, 0f);
        gameObject.SetActive(true);
    }
    private void StopParticles()
    {
        Globals.particleActive = false;
    }
}
