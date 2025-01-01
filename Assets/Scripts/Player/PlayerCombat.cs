using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Sword;

public class PlayerCombat : MonoBehaviour
{
	public Weapon currentWeapon;
	public Animator animator;
	public Transform meleeEffectSpawnPoint;

	public int weaponType;

	public float attackCooldown;
	public float attackTimer;
	public FloatingBar attackCooldownBar;

	public GameObject punchEffect;
	public bool canApplyDamage;
	public float damage;
	public Transform hitBox;
	public float hitRadius;
	public LayerMask enemyLayer;
	public HashSet<GameObject> hitEnemies = new HashSet<GameObject>();

	private PlayerController playerController;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		playerController = GetComponent<PlayerController>();
		attackTimer = attackCooldown;
	}

	// Update is called once per frame
	void Update()
	{
		if (playerController.isDashing) return;

		Attack();
		if (attackTimer <= attackCooldown)
			attackCooldownBar.UpdateValueBar(attackTimer, attackCooldown);

		if (canApplyDamage)
		{
			PerformOverlapCheck();
		}

		animator.SetInteger("weaponType", weaponType);
	}

	void PerformOverlapCheck()
	{
		Collider[] hitColliders = Physics.OverlapSphere(hitBox.position, hitRadius, enemyLayer);

		foreach (Collider hitCollider in hitColliders)
		{
			if (hitEnemies.Contains(hitCollider.gameObject)) continue;
			hitEnemies.Add(hitCollider.gameObject);
			Vector3 closetPoint = hitCollider.ClosestPoint(hitBox.position);
			DealDamage(hitCollider.gameObject);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(hitBox.position, hitRadius);
	}

	protected virtual void DealDamage(GameObject enemy)
	{
		EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
		if (enemyHealth != null)
		{
			enemyHealth.TakeDamage(damage);
		}
	}

	void Attack()
	{
        if (Input.GetKeyDown(KeyCode.C) && attackTimer >= attackCooldown)
		{

			if (currentWeapon != null)
			{
				currentWeapon.Attack();
			}
			else
			{
				animator.SetTrigger("isAttack");
			}

			attackTimer = 0;
		}

		if (attackTimer <= attackCooldown)
		{
			attackTimer += Time.deltaTime;
		}
	}

	public void SpawnEffect(string effectName)
	{
		if(currentWeapon != null)
		{
			currentWeapon.SpawnEffect(effectName);
		}
		else
		{
			Vector3 offset = transform.forward * .2f;
			Instantiate(punchEffect, meleeEffectSpawnPoint.position + offset, meleeEffectSpawnPoint.rotation, meleeEffectSpawnPoint);
		}
	}

	public void ApplyDamage()
	{
		if (currentWeapon != null && currentWeapon is MeleeWeapon)
		{
			currentWeapon.ApplyDamage();
		}
		else
		{
			canApplyDamage = true;
		}
		hitEnemies.Clear();
	}

	public void EndAttack()
	{
		if (currentWeapon != null && currentWeapon is MeleeWeapon)
		{
			currentWeapon.EndAttack();
		}
		else
		{
			canApplyDamage = false;
		}
		hitEnemies.Clear();
	}

	public Transform Traverse(Transform parent, string name)
	{
		// Kiểm tra nếu nút hiện tại có tên cần tìm
		if (parent.name == name) return parent;

		// Duyệt qua các con của nút hiện tại
		foreach (Transform child in parent)
		{
			Transform result = Traverse(child, name); // Gọi đệ quy
			if (result != null) return result; // Nếu tìm thấy, trả về ngay
		}

		// Không tìm thấy trong cây con, trả về null
		return null;
	}

	public void EquipWeapon(GameObject weapon, int _weaponType)
	{
		currentWeapon = weapon.GetComponent<Weapon>();
		currentWeapon.slashEffectSpawnPoint = meleeEffectSpawnPoint;
		currentWeapon.effects = FindObjectOfType<EffectAssets>().effects;
		weaponType = _weaponType;

		currentWeapon.SetPlayerCombat(this);
	}

}
