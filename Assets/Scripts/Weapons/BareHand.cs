using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BareHand : MeleeWeapon
{
	public override void Attack()
	{
		playerCombat.animator.SetTrigger("isAttack");
	}

	public override void ApplyDamage()
	{
		base.ApplyDamage();
	}

	public override void EndAttack()
	{
		base.EndAttack();
	}
}
