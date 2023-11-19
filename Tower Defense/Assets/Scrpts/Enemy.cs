using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    
    private Transform target;
    private int wavepointIndex = 0;

    public float startSpeed = 10f;
    public float startHealth = 100;
    public float speed = 10f;
    public int worth = 10;

	private float health;

    void Start() {
        target = Waypoints.points[0];
        speed = startSpeed;
		health = startHealth;
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
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
