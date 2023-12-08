using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
    public static int EnemiesAlive = 0;

    // public Transform enemyPrefab;
    public Wave[] waves;
    public Transform spawnPoint;
    public GameManager gameManager;

    public Text waveCountdownHeadding;
    public Text waveCountdownText;
    public Button startNextWave;

    public float waveTimer = 5f;
    private float countdown = 2f;
    public static int curretnWave;
    public int waveNumber;
    public int bonus = 2;
    private int totalBonus;

    void Start ()
    {
        waveNumber = 0;
        EnemiesAlive = 0;
        curretnWave = 1;
    }

    void Update() 
    {
        if (EnemiesAlive > 0)
		{
            waveCountdownHeadding.text = "Enemies Remaining";
            waveCountdownText.text = EnemiesAlive.ToString();
			return;
		}

        if (waveNumber == waves.Length)
		{
			gameManager.LevelWon();
			this.enabled = false;
		}

        if(countdown <= 0f) 
        {
            StartCoroutine(SpawnWave());
            countdown = waveTimer;
            return;
        }

        countdown -= Time.deltaTime;
        waveCountdownHeadding.text = "Next Wave In";
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave() 
    {
        curretnWave = waveNumber + 1;
        Wave wave = waves[waveNumber];
        for (int i = 0; i < wave.count; i++) 
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveNumber ++;
    }

    public void SpawnNextWave ()
    {
        // Rewards the player with extra money if they start the next wave early
        if (startNextWave)
        {
            totalBonus += bonus * EnemiesAlive;
            if (totalBonus > 20)
                totalBonus = 20;
            PlayerStats.Currancy += totalBonus;
        }
        StartCoroutine(SpawnWave());
        countdown = waveTimer;
    }

    void SpawnEnemy(GameObject enemy) 
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}