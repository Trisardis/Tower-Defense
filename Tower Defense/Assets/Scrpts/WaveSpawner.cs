using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
    public static int EnemiesAlive = 0;

    public Transform enemyPrefab;
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
        }

        countdown -= Time.deltaTime;
        waveCountdownHeadding.text = "Next Wave In";
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave() 
    {
        curretnWave = waveNumber;
        waveNumber ++;
        for (int i = 0; i < waveNumber; i++) 
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void SpawnNextWave ()
    {
        Debug.Log("Spawn Next Wave");
        StartCoroutine(SpawnWave());
        countdown = waveTimer;
    }

    void SpawnEnemy() 
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}