using UnityEngine;

public class playerController : MonoBehaviour
{

    public delegate void playerDied();
    public static event playerDied onPlayerDeath;
    
    private Config config;
    private Animator anim;
    private GoalHandler goalHandler;
    private ExplosionHandler explosionHandler;

    DestroySelf destroySelf;
    private void Start()
    {
        //I added a few extras to the config file  that effect the player which is why I am loading it here
        config = Resources.Load<Config>("Config/SceneConfig");
        anim = GetComponent<Animator>();
        destroySelf = GetComponent<DestroySelf>();
        goalHandler = GetComponent<GoalHandler>();
        explosionHandler = GetComponent<ExplosionHandler>();
    }

    //using fixed update as this will be in step with the rigid body and should stop the player begin able to teleport through the enemies...hopefully
    void FixedUpdate()
    {
        moveToGoal();
        transform.LookAt(goalHandler.getGoalPosition());
    }

    void moveToGoal() 
    {
        Vector3 goalPosition = goalHandler.getGoalPosition();
        transform.position = Vector3.MoveTowards(transform.position, goalPosition, config.playerSpeed * Time.deltaTime);

        if (transform.position == goalHandler.getGoalPosition()) 
        {
            goalHandler.updateGoal();
        }
    }

    //this is public so I could make use of it in the animator    
    public void destroyPlayer()
    {
        explosions();
        destroySelf.destroyGameobject();
        onPlayerDeath();
    }

    public void playFinishAnimation() 
    {
        anim.SetTrigger("Finish");
    }

    void explosions()
    {
        explosionHandler.addExplosions();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Enemy")
        {
            destroyPlayer();
        }
    }
}