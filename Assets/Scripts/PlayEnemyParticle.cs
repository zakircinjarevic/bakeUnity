using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEnemyParticle : MonoBehaviour
{
    public ParticleSystem particles;
    void Update()
    {
        if (Globals.enemyParticleActive == true)
        {
            particles.transform.position = Globals.enemyPosition;
            particles.enableEmission = true;
        }
        else
        {
            particles.enableEmission = false;
        }
    }
}
