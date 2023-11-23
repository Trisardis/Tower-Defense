using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool LevelCompleated;

	public GameObject gameOverUI;
	public GameObject LevelCompleatedUI;

	void Start ()
	{
        LevelCompleated = false;
		GameIsOver = false;
        LevelCompleatedUI.SetActive(false);
        gameOverUI.SetActive(false);
	}

    void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
                pauseGame();
            else
                resumeGame();
        }

        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
        if (WaveSpawner.curretnWave == 9 && WaveSpawner.EnemiesAlive == 0)
        {
            LevelWon();
        }
    }

    void LevelWon ()
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
    }

    void resumeGame ()
    {
        Time.timeScale = 1;
    }
}
