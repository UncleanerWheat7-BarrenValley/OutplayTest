using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Vector3[] positionArray;
    public ParticleSystem[] explosionParticles;


    private int currentGoal;
    private bool moving;
    private Config config;
    private Animator anim;

    DestroySelf destroySelf;
    private void Start()
    {
        config = Resources.Load<Config>("Config/SceneConfig");
        anim = GetComponent<Animator>();
        destroySelf = GetComponent<DestroySelf>();
        currentGoal = 0;
        moving = true;
        positionArray = new[] { config.position1, config.position2, config.position3 };
        print(positionArray[currentGoal]);
    }
    void FixedUpdate()
    {
        if (!moving) return;

        transform.position = Vector3.MoveTowards(transform.position, positionArray[currentGoal], config.playerSpeed * Time.deltaTime);

        if (transform.position == positionArray[currentGoal] && currentGoal < 2)
        {
            currentGoal++;
        }
        else if (transform.position == positionArray[currentGoal] && currentGoal == 2)
        {
            anim.SetTrigger("Finish");
        }

        transform.LookAt(positionArray[currentGoal]);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            destroyPlayer();
        }
    }

    public void destroyPlayer()
    {
        moving = false;
        explosions();
        destroySelf.destroyGameobject();
    }
    void explosions()
    {
        foreach (ParticleSystem particleSystem in explosionParticles)
        {
            Instantiate(particleSystem, transform.position, transform.rotation);
        }
    }
}