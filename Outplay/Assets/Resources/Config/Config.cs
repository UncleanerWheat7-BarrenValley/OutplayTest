using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Config : ScriptableObject
{
    public int numberOfEnemies;
    public float enemyXDistance;
    public float enemyYDistance;
    public float enemyZDistance;
    public List<Vector3> positions;  
    public float playerSpeed;
}
