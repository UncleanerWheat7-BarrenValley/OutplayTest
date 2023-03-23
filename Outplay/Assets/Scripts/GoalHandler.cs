using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHandler : MonoBehaviour
{
    int currentGoal;
    public List <Vector3> goalPositionList;
    private Config config;

    private void Start()
    {
        //I added a few extras to the config file  that effect the player which is why I am loading it here
        config = Resources.Load<Config>("Config/SceneConfig");
        foreach (Vector3 vector3 in config.positions)
        {
            goalPositionList.Add(vector3);
        }
        currentGoal = 0;
    }

    public Vector3 getGoalPosition()
    {
        transform.LookAt(goalPositionList[currentGoal]);
        return goalPositionList[currentGoal];
    }

    public void updateGoal()
    {
        if (transform.position == goalPositionList[currentGoal] && currentGoal < 2)
        {
            currentGoal++;
        }
        else
        {
            GetComponent<playerController>().playFinishAnimation();
        }
    }
}
