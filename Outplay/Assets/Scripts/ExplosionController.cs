using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        if (GetComponent<AudioSource>())
        {
            audioSource = GetComponent<AudioSource>();
            int randomSound = Random.Range(1, 31);

            AudioClip audioClip = Resources.Load<AudioClip>("explosionsoundslite/sounds/Explosion" + randomSound.ToString());
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        GetComponent<DestroySelf>().destroyGameobject(GetComponent<ParticleSystem>().main.duration);
    }
}
