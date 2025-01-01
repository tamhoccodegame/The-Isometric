using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float speed;
    public float damage;
	public float lifeTime;
	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.AddForce(speed * transform.parent.forward, ForceMode.Impulse);
		transform.parent = null;
		Destroy(gameObject, lifeTime);
	}

	private void OnTriggerEnter(Collider other)
	{
		EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
		if (enemyHealth != null)
		{
			enemyHealth.TakeDamage(damage);
		}
	}
}
