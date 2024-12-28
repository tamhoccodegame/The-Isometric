using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
	public Collider hitBox;
	public GameObject currentImpact;

	public ParticleSystem effect;
	public GameObject hitEffect;
	public override void Attack()
	{
		StartCoroutine(AttackCoroutine());       
	}

	IEnumerator AttackCoroutine()
	{
		yield return new WaitForSeconds(0.2f);
	}

	public override void ApplyDamage()
	{
		hitBox.enabled = true;
	}

	public override void EndAttack()
	{
		hitBox.enabled = false;
	}

	protected virtual void OnTriggerEnter(Collider other)
	{
		if (currentImpact != null & other.gameObject == currentImpact) return;
		EnemyHealth enemy = other.GetComponent<EnemyHealth>();
		if (enemy != null && currentImpact != enemy.gameObject)
		{
			enemy.TakeDamage(damage);
			currentImpact = enemy.gameObject;
			Debug.DrawLine(transform.position, other.ClosestPoint(transform.position), Color.red, 2f);

			var go = Instantiate(hitEffect, other.ClosestPoint(transform.position), Quaternion.identity);
			Destroy(go, 2f);
		}
	}
	protected virtual void OnTriggerExit(Collider other)
	{
		EnemyHealth enemy = other.GetComponent<EnemyHealth>();
		if(enemy != null && currentImpact == other.gameObject)
			currentImpact = null;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
