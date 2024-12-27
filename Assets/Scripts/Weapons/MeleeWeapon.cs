using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
	public Collider hitBox;
	public GameObject currentImpact;
	public override void Attack()
	{
		StartCoroutine(AttackCoroutine());       
	}

	IEnumerator AttackCoroutine()
	{
		yield return new WaitForSeconds(0.2f);
		hitBox.enabled = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		EnemyHealth enemy = other.GetComponent<EnemyHealth>();
		if (enemy != null && currentImpact != enemy.gameObject)
		{
			enemy.TakeDamage(damage);
			currentImpact = enemy.gameObject;
		}
		else return;
	}
	private void OnTriggerExit(Collider other)
	{
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
