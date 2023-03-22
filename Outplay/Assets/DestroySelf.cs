using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public void destroyGameobject(float time = 0) 
    {        
        Destroy(gameObject, time);    
    }
}
