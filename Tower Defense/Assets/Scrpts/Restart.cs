using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour
{
    public void RestartGame() 
    {
        // loads current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 

        // Resume game if it was paused
        if (GameManager.gamePaused == true)
            Time.timeScale = 1;
    }
}
