using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip jumpSound, deathSound, enemyDeathSound;
    public static AudioSource audioSrc;
    void Start()
    {
        jumpSound = Resources.Load("playerJump") as AudioClip;
        deathSound = Resources.Load("playerDeath") as AudioClip;
        enemyDeathSound = Resources.Load("goomba-dead") as AudioClip;
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
            {
                audioSrc.PlayOneShot(jumpSound, 0.05f);
                break;
            }
            case "death":
            {
                audioSrc.PlayOneShot(deathSound, 0.25f);
                break;
            }
            case "enemy-death":
            {
                audioSrc.PlayOneShot(enemyDeathSound, 0.25f);
                break;
            }
        }
    }
}
