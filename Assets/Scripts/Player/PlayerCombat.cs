using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Sword;

public class PlayerCombat : MonoBehaviour
{
	public Weapon currentWeapon;
	public int currentWeaponUpgradeSkill;
	public Animator animator;

	public int weaponType;
	public Transform meleeEffectSpawnPoint;

    public float attackCooldown;
	public float attackTimer;
	public FloatingBar attackCooldownBar;

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

		animator.SetInteger("weaponType", weaponType);
	}

	void Attack()
	{
        if (Input.GetKeyDown(KeyCode.C) && attackTimer >= attackCooldown)
		{

			if (currentWeapon != null)
			{
				currentWeapon.Attack();
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
	}

	public void ApplyDamage()
	{
		if (currentWeapon != null)
		{
			currentWeapon.ApplyDamage();
		}
	}

	public void EndAttack()
	{
		if (currentWeapon != null && currentWeapon is MeleeWeapon)
		{
			currentWeapon.EndAttack();
		}
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
		if(currentWeapon != null) currentWeapon.DropWeapon();
		animator.Play("Null");
		currentWeapon = weapon.GetComponent<Weapon>();
		currentWeapon.slashEffectSpawnPoint = meleeEffectSpawnPoint;
		currentWeapon.effects = FindObjectOfType<EffectAssets>().effects;
		weaponType = _weaponType;
		currentWeapon.currentSkillLevel = currentWeaponUpgradeSkill;
		attackCooldown = currentWeapon.attackCooldown;
		attackTimer = attackCooldown;
		currentWeapon.SetPlayerCombat(this);
	}

}
