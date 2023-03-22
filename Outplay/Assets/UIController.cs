using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void pressPlay() 
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void pressQuit()
    {
        Application.Quit();
    }
}
