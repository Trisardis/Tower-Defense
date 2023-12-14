using System.Collections;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool LevelCompleated;
    public static bool gamePaused;

	public GameObject gameOverUI;
	public GameObject LevelCompleatedUI;
    public GameObject pauseMenuUI;
    public GameObject introductionScreenUI;

    public TowerBase towerBase;

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
        giveRandomTower();
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

    void giveRandomTower()
    {
        float towerNumber = UnityEngine.Random.Range(1, 4);
        if (towerNumber == 1)
            TowerManager.orangeCatAmount += 1;
        else if (towerNumber == 2)
           TowerManager.whiteCatAmount += 1;
        else
            TowerManager.fatCatAmount += 1;

        // TowerBase.towerBlueprint.amountLeft = 10;
    }
}
