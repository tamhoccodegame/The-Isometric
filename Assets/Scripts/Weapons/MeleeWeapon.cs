using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
	public float hitRadius;
	public Transform hitboxStart;
	public Transform hitboxEnd;
	public bool canApplyDamage = false;

	public HashSet<GameObject> hitEnemies = new HashSet<GameObject>();
	public Hitbox[] hitboxs;

    public override void Attack()
	{
		
	}

    public override void ApplyDamage(int hitboxIndex = 0)
	{
		hitboxs[hitboxIndex].canApplyDamage = true;
	}

	public override void EndAttack(int hitboxIndex = 0)
	{
        hitboxs[hitboxIndex].canApplyDamage = false;
	}

    void Start()
    {
		weaponType = 1;
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

		//Collider[] hitColliders = Physics.OverlapCapsule(start, end, hitRadius, enemyLayer);

		//foreach (Collider hitCollider in hitColliders)
		//{
		//	if(hitEnemies.Contains(hitCollider.gameObject)) continue;
		//	hitEnemies.Add(hitCollider.gameObject);
		//	Vector3 closetPoint = hitCollider.ClosestPoint((start + end) / 2);
		//	SpawnHitEffect(closetPoint);
		//	DealDamage(hitCollider.gameObject);
		//}
	}

    protected override void SpawnHitEffect(Vector3 position)
	{
		base.SpawnHitEffect(position);
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
