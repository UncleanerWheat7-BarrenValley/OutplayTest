using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    //I made this a seperate script so the component can be attached to the player and the particle effects and allows for a delay timer
    public void destroyGameobject(float time = 0) 
    {        
        Destroy(gameObject, time);    
    }
}
