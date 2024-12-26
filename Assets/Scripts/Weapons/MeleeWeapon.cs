using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
	public Collider hitBox;
	public override void Attack()
	{
		StartCoroutine(AttackCoroutine());       
	}

	IEnumerator AttackCoroutine()
	{
		yield return new WaitForSeconds(0.2f);
		hitBox.enabled = true;
		yield return new WaitForSeconds(0.5f);
		hitBox.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		EnemyHealth enemy = other.GetComponent<EnemyHealth>();
		if (enemy != null)
			enemy.TakeDamage(damage);
		else return;
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
