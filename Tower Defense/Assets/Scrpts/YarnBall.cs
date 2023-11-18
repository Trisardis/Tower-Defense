using UnityEngine;

public class YarnBall : MonoBehaviour
{
private Transform target;
public float speed = 70f;
public int damage = 50;
public float explosionRadius = 0f;
public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate (dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget ()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);

        if (explosionRadius > 0f) {
			Explode();
		} 
        else
		{
			Damage(target);
		}

        Destroy(target.gameObject);
        Destroy(gameObject);
    }

    void Explode ()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            Debug.Log(collider.gameObject);
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage (Transform enemy)
	{
		// Enemy enemy = enemy.GetComponent<Enemy>();
		// if (enemy != null)
		// {
		// 	enemy.TakeDamage(damage);
		// }
        Destroy(enemy.gameObject);
        // foreach(Transform child in enemy.transform)
        // {
        //     Destroy(child.gameObject);
        // }
	}
}

    
