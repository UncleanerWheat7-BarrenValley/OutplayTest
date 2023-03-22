using UnityEngine;

[CreateAssetMenu]
public class Config : ScriptableObject
{
    public int numberOfEnemies;
    public float enemyXDistance;
    public float enemyYDistance;
    public float enemyZDistance;
    public Vector3 position1;
    public Vector3 position2;
    public Vector3 position3;
    public float playerSpeed;
}
