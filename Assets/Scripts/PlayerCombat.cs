using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	public Weapon currentWeapon;
	public bool isRangeWeapon;
	private Animator animator;

	public float attackCooldown;
	public float attackTimer;
	public FloatingBar attackCooldownBar;
	private bool hasWeapon = false;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		attackTimer = attackCooldown;
	}

	// Update is called once per frame
	void Update()
	{
		Attack();
		if (attackTimer <= attackCooldown)
			attackCooldownBar.UpdateValueBar(attackTimer, attackCooldown);
		animator.SetBool("isRangeWeapon", isRangeWeapon);
		animator.SetBool("hasWeapon", hasWeapon); 
	}


	void Attack()
	{
		if (Input.GetKeyDown(KeyCode.C) && attackTimer >= attackCooldown)
		{
			animator.SetTrigger("isAttack");
			currentWeapon.Attack();

			attackTimer = 0;
		}

		if (attackTimer <= attackCooldown)
		{
			attackTimer += Time.deltaTime;
		}
	}

	public void ApplyDamage()
	{
		if (currentWeapon != null && currentWeapon is MeleeWeapon)
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


	[ContextMenu("PickUpWeapon")]
	public void PickUpWeaponA()
	{
		PickUpWeapon("MagicOrb");
	}

	public void PickUpWeapon(string weaponName)
	{
		currentWeapon.gameObject.SetActive(false);
		Transform w = Traverse(transform, weaponName);
		Debug.Log(w.name);
		w.gameObject.SetActive(true);
		currentWeapon = w.GetComponent<Weapon>();
		isRangeWeapon = currentWeapon is RangeWeapon;
	}
}
