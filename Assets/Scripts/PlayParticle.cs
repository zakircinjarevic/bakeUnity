using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    public ParticleSystem particles;
    void Update()
    {
        if(Globals.particleActive == true)
        {
            particles.transform.position = Globals.playerPosition;
            particles.enableEmission = true;
        } else
        {
            particles.enableEmission = false;
        }
    }
}
