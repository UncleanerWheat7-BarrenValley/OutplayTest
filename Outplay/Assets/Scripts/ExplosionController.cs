using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    AudioSource audioSource;
    DestroySelf destroySelf;
    ParticleSystem particle;
    int numberOfSoundEffects;
    void Start()
    {
        destroySelf = GetComponent<DestroySelf>();
        particle = GetComponent<ParticleSystem>();

        if (GetComponent<AudioSource>())
        {    
            //There are a lot of sounds for the explosion so here I get the number of clips and choose one at random when the clip is played
            foreach (AudioClip sound in Resources.LoadAll<AudioClip>("explosionsoundslite/sounds"))
            {
                numberOfSoundEffects++;
            }

            audioSource = GetComponent<AudioSource>();
            int randomSound = Random.Range(1, numberOfSoundEffects);
            AudioClip audioClip = Resources.Load<AudioClip>("explosionsoundslite/sounds/Explosion" + randomSound.ToString());            
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        destroySelf.destroyGameobject(particle.main.duration);
    }
}
