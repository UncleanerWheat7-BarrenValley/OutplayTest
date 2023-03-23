using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    void Start()
    {
        playerController.onPlayerDeath += death;
        Time.timeScale = 0;
    }

    public void pressPlay()
    {
        Time.timeScale = 1;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void pressRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void death()
    {
        playerController.onPlayerDeath -= death;
        StartCoroutine(Countdown());
    }

    public void pressQuit()
    {
        Application.Quit();
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(3);
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
