using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeleeWeapon
{
	public override void Attack()
	{
		if (currentSkillLevel == 0) playerCombat.animator.SetTrigger("isAttack");
		else UseSkill(currentSkillLevel);
	}

	public override void ApplyDamage(int hitboxIndex = 0)
	{
		base.ApplyDamage();
	}

	public override void EndAttack(int hitboxIndex = 0)
	{
		base.EndAttack();
	}

	
	public override void UseSkill(int currentSkillLevel)
	{
		switch(currentSkillLevel)
		{
			case 1:
				DoubleSlash();
				break;
			case 2:
				Whirlwind();
				break;
			case 3:
				DashAttack();
				break;
		}
	}

	void DoubleSlash()
	{
		playerCombat.animator.SetTrigger("DoubleSlash");
	}

	void Whirlwind()
	{
		playerCombat.animator.SetTrigger("Whirlwind");
	}
	
	void DashAttack()
	{
		playerCombat.animator.SetTrigger("DashAttack");
	}

}
