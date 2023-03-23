using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    public ParticleSystem[] explosionParticles;

    public void addExplosions() 
    {
        //I have two explosions so I created an array in case I wanted to add more in the future
        foreach (ParticleSystem particleSystem in explosionParticles)
        {
            Instantiate(particleSystem, transform.position, transform.rotation);
        }
    }
}
