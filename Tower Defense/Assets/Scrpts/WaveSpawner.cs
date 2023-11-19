using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float waveTimer = 5f;
    private float countdown = 2f;

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
        if(countdown <= 0f) 
        {
            StartCoroutine(SpawnWave());
            countdown = waveTimer;
        }

        countdown -= Time.deltaTime;
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
    }
}