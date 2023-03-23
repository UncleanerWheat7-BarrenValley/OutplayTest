using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHandler : MonoBehaviour
{
    int currentGoal;
    public Vector3[] goalPositionArray;
    private Config config;

    private void Start()
    {
        //I added a few extras to the config file  that effect the player which is why I am loading it here
        config = Resources.Load<Config>("Config/SceneConfig");
        goalPositionArray = new[] { config.position1, config.position2, config.position3 };
        currentGoal = 0;
    }

    public Vector3 getGoalPosition()
    {
        return goalPositionArray[currentGoal];
    }

    public void updateGoal()
    {
        if (transform.position == goalPositionArray[currentGoal] && currentGoal < 2)
        {
            currentGoal++;
        }
        else
        {
            GetComponent<playerController>().playFinishAnimation();
        }
    }
}
