using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex = 0;

    public float startSpeed = 10f;
    public float startHealth = 100;
    public float health;
    public float speed = 10f;
    public int worth = 10;

    public Image healthBar;
    public AudioSource audioSource;
    public AudioClip enemyHhit;


    private bool isDead = false;

    void Start() {
        target = Waypoints.points[0];
        speed = startSpeed;
		health = startHealth;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f){
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() {
        if (wavepointIndex >= Waypoints.points.Length - 1) {
            PlayerStats.Lives -= 1;
            WaveSpawner.EnemiesAlive--;
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    public void TakeDamage (float amount)
	{
        audioSource.PlayOneShot(enemyHhit, 1);
        health -= amount;
		healthBar.fillAmount = health / startHealth;
		if (health <= 0 && !isDead)
		{
            Debug.Log("Dead");
			Die();
		}
	}

    void Die ()
	{
        audioSource.PlayOneShot(enemyHhit, 1);
		isDead = true;
		PlayerStats.Currancy += worth;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}
}
