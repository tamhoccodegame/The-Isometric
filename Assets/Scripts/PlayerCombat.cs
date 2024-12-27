using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Weapon currentWeapon;
	private Animator animator;

	public float attackCooldown;
	public float attackTimer;
	public FloatingBar attackCooldownBar;

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
		if(attackTimer <= attackCooldown)
		attackCooldownBar.UpdateBar(attackTimer, attackCooldown);
    }


	void Attack()
	{
		if (Input.GetKeyDown(KeyCode.C) && attackTimer >= attackCooldown)
		{
			if(currentWeapon == null)
			{
				animator.SetTrigger("isAttack");
			}
			else
			{
				if(currentWeapon is MeleeWeapon meleeWeapon)
				{
					animator.SetTrigger("isAttack");
					meleeWeapon.Attack();
				}
				else if(currentWeapon is RangeWeapon)
				{
					animator.SetTrigger("isFire");
				}
			}

			attackTimer = 0;
		}

		if (attackTimer <= attackCooldown)
		{
			attackTimer += Time.deltaTime;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		
	}
}
