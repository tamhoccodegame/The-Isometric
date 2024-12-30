using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeleeWeapon
{
	private void Start()
	{
		currentSkillType = SkillType.None;
	}
	public override void Attack()
	{
		if (currentSkillType != SkillType.None)
			UseSkill();
		else playerCombat.animator.SetTrigger("isAttack");
	}

	public override void ApplyDamage()
	{
		base.ApplyDamage();
	}

	public override void EndAttack()
	{
		base.EndAttack();
	}

	
	public override void UseSkill()
	{
		switch(currentSkillType)
		{
			case SkillType.DoubleSlash:
				DoubleSlash();
				break;
			case SkillType.Whirlwind:
				Whirlwind();
				break;
			case SkillType.DashAttack:
				DashAttack();
				break;
		}
	}

	[ContextMenu("DoubleSlash")]
	public void UseSkill1()
	{
		UpgradeSkill(SkillType.DoubleSlash);
	}

	void DoubleSlash()
	{
		playerCombat.animator.SetTrigger("DoubleSlash");
	}

	void Whirlwind()
	{
		playerCombat.animator.SetTrigger("Whirlwind");

		Transform hitBox = playerCombat.whirlwindHitbox;

		Collider[] hitColliders = Physics.OverlapSphere(hitBox.position, .5f, enemyLayer);

		foreach (Collider hitCollider in hitColliders)
		{
			if (hitEnemies.Contains(hitCollider.gameObject)) continue;
			hitEnemies.Add(hitCollider.gameObject);
			Vector3 closetPoint = hitCollider.ClosestPoint(hitBox.position);
			SpawnHitEffect(closetPoint);
			DealDamage(hitCollider.gameObject);
		}
	}
	
	void DashAttack()
	{

	}

	public void UpgradeSkill(SkillType _skillType)
	{
		currentSkillType = _skillType;
		switch (currentSkillType)
		{
			case SkillType.DoubleSlash:
				
				break;
			case SkillType.Whirlwind:
				
				break;
			case SkillType.DashAttack:
				
				break;
		}
	}

}
