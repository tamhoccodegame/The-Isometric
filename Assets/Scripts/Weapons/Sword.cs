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
	}
	
	void DashAttack()
	{
		playerCombat.animator.SetTrigger("DashAttack");
		//StartCoroutine(DashAttackCoroutine());
	}

	IEnumerator DashAttackCoroutine()
	{
		float dashDuration = 0.2f;
		float dashTimeLeft = dashDuration;
		float dashSpeed = 20f;

		PlayerController playerController = FindObjectOfType<PlayerController>();
		playerController.enabled = false;

        while (dashTimeLeft > 0f)
        {
			FindObjectOfType<CharacterController>().Move(dashSpeed * playerController.transform.forward * Time.deltaTime);
			dashTimeLeft -= Time.deltaTime; 
			yield return null;
        }

		playerController.enabled = true;
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
