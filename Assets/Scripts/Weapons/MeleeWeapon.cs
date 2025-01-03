using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
	public GameObject hitEffect;
	public float hitRadius;
	public Transform hitboxStart;
	public Transform hitboxEnd;
	public LayerMask enemyLayer;
	public bool canApplyDamage = false;

	public HashSet<GameObject> hitEnemies = new HashSet<GameObject>();

	public override void Attack()
	{

	}

	public override void ApplyDamage()
	{
		canApplyDamage = true;
		hitEnemies.Clear();
	}

	public override void EndAttack()
	{
		canApplyDamage = false;
		hitEnemies.Clear();
	}
	// Update is called once per frame
	protected override void Update()
	{
		base.Update();
		if (!canApplyDamage) return;
		PerformOverlapCheck();
	}

	public virtual void PerformOverlapCheck()
	{
		Vector3 start = hitboxStart.position;
		Vector3 end = hitboxEnd.position;

		Collider[] hitColliders = Physics.OverlapCapsule(start, end, hitRadius, enemyLayer);

		foreach (Collider hitCollider in hitColliders)
		{
			if(hitEnemies.Contains(hitCollider.gameObject)) continue;
			hitEnemies.Add(hitCollider.gameObject);
			Vector3 closetPoint = hitCollider.ClosestPoint((start + end) / 2);
			SpawnHitEffect(closetPoint);
			DealDamage(hitCollider.gameObject);
		}
	}
	protected void SpawnHitEffect(Vector3 position)
	{
		GameObject effect = Instantiate(hitEffect, position, Quaternion.identity);
		Destroy(effect, 2f);
	}

	protected virtual void DealDamage(GameObject enemy)
	{
		EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
		if (enemyHealth != null)
		{
			enemyHealth.TakeDamage(damage);
			ApplyEffect(enemy);
		}
	}

	private void OnDrawGizmos()
	{
		if (hitboxStart == null || hitboxEnd == null) return;

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(hitboxStart.position, hitRadius); // Đầu hitbox
		Gizmos.DrawWireSphere(hitboxEnd.position, hitRadius);   // Cuối hitbox

		// Vẽ đường nối giữa hai điểm
		Gizmos.DrawLine(hitboxStart.position, hitboxEnd.position);
	}

}
