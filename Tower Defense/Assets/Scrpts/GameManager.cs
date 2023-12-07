using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool LevelCompleated;
    public static bool gamePaused;

	public GameObject gameOverUI;
	public GameObject LevelCompleatedUI;
    public GameObject pauseMenuUI;
    public GameObject introductionScreenUI;

	void Start ()
	{
        LevelCompleated = false;
		GameIsOver = false;
        gamePaused = false;
        LevelCompleatedUI.SetActive(false);
        gameOverUI.SetActive(false);
        pauseMenuUI.SetActive(false);

        introductionScreenUI.SetActive(true);
        Time.timeScale = 0;
	}

    void Update () 
    {
        // Dissable introduction screen when the game
        if (Time.timeScale == 1)
            introductionScreenUI.SetActive(false);

        // Pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
                pauseGame();
            else 
                resumeGame();
        }

        // Win / Loose logic
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    public void LevelWon ()
    {
        pauseGame();
        LevelCompleated = true;
        LevelCompleatedUI.SetActive(true);
    }

    void EndGame ()
    {
        pauseGame();
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    void pauseGame ()
    {
        Time.timeScale = 0;
        gamePaused = true;
        pauseMenuUI.SetActive(true);
    }

    void resumeGame ()
    {
        Time.timeScale = 1;
        gamePaused = false;
        pauseMenuUI.SetActive(false);
    }
}
