using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
    public static int EnemiesAlive = 0;

    // public Transform enemyPrefab;
    public Wave[] waves;

    public Transform spawnPoint;

    public float waveTimer = 5f;
    private float countdown = 2f;

    public Text waveCountdownHeadding;
    public Text waveCountdownText;
    public Button startNextWave;

    public static int curretnWave;
    public int waveNumber = 0;

    void Start ()
    {
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
        Wave wave = waves[waveNumber];
        for (int i = 0; i < wave.count; i++) 
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        curretnWave = waveNumber;
        waveNumber ++;
    }

    public void SpawnNextWave ()
    {
        StartCoroutine(SpawnWave());
        countdown = waveTimer;
    }

    void SpawnEnemy(GameObject enemy) 
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}