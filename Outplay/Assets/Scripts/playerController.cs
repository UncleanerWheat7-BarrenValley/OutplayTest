using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public ParticleSystem[] explosionParticles;

    private Vector3[] goalPositionArray;
    private int currentGoal;
    private bool moving;
    private Config config;
    private Animator anim;
    private Rigidbody rb;

    DestroySelf destroySelf;
    private void Start()
    {
        //I added a few extras to the config file  that effect the player which is why I am loading it here
        config = Resources.Load<Config>("Config/SceneConfig");
        anim = GetComponent<Animator>();
        destroySelf = GetComponent<DestroySelf>();
        rb = GetComponent<Rigidbody>();


        currentGoal = 0;
        moving = true;
        goalPositionArray = new[] { config.position1, config.position2, config.position3 };
    }

    //using fixed update as this will be in step with the rigid body and should stop the player begin able to teleport through the enemies...hopefully
    void FixedUpdate()
    {
        //An early out to stop the loop if the player has reached their goal
        if (!moving) return;

        moveToGoal();
        handleReachingGoals();
    }

    void moveToGoal() 
    {
        transform.position = Vector3.MoveTowards(transform.position, goalPositionArray[currentGoal], config.playerSpeed * Time.deltaTime);    
    }

    void handleReachingGoals()
    {
        if (transform.position == goalPositionArray[currentGoal] && currentGoal < 2)
        {
            currentGoal++;
        }
        else if (transform.position == goalPositionArray[currentGoal] && currentGoal == 2)
        {
            moving = false;
            anim.SetTrigger("Finish");
        }

        transform.LookAt(goalPositionArray[currentGoal]);
    }

    //this is public so I could make use of it in the animator    
    public void destroyPlayer()
    {
        explosions();
        destroySelf.destroyGameobject();
    }

    void explosions()
    {
        //I have two explosions so I created an array in case I wanted to add more in the future
        foreach (ParticleSystem particleSystem in explosionParticles)
        {
            Instantiate(particleSystem, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            destroyPlayer();
        }
    }
}