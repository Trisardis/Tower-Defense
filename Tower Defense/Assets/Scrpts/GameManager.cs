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
        Debug.Log(WaveSpawner.curretnWave);
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
        LevelCompleated = true;
        LevelCompleatedUI.SetActive(true);
    }

    void EndGame ()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
