using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public GameObject enemy;
    private Config config;
    
    // Start is called before the first frame update
    void Start()
    {
        config = Resources.Load<Config>("Config/SceneConfig");
        for (int i = 0; i < config.numberOfEnemies; i++)
        {
            Vector3 randomVector3 = new Vector3(
                Random.Range(-config.enemyXDistance, config.enemyXDistance), 
                Random.Range(-config.enemyYDistance, config.enemyYDistance), 
                Random.Range(-config.enemyZDistance, config.enemyZDistance));

            Instantiate(enemy, randomVector3, Quaternion.identity);
        }
    }
}
