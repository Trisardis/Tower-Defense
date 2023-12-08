using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIButtons : MonoBehaviour
{
    public void startGame()
    {
        Time.timeScale = 1;
    }

    public void RestartGame() 
    {
        // loads current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 

        // Resume game if it was paused
        if (GameManager.gamePaused == true)
            Time.timeScale = 1;
    }

    public void StartNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
