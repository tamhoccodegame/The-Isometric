using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BleedingEffect : BaseEffect
{
	public float damagePerTick;
	public float duration;
	Coroutine bleedingCoroutine = null;

	protected override void Start()
	{
		base.Start();
		UpgradeEffect();
	}

	public override void ApplyEffect(GameObject target)
	{
		if(bleedingCoroutine != null)
		{
			StopCoroutine(bleedingCoroutine);
		}

		bleedingCoroutine = StartCoroutine(BleedingEffectCoroutine(target));
	}

	IEnumerator BleedingEffectCoroutine(GameObject target)
	{
		float elapsedTime = 0f;
		EnemyHealth enemy = target.GetComponent<EnemyHealth>();
		while (elapsedTime < duration)
		{
			enemy.TakeDamage(damagePerTick);
			elapsedTime += 1f;
			yield return new WaitForSeconds(1f);
		}

		RemoveEffect(target);
	}

	public override void RemoveEffect(GameObject target)
	{
		
	}

	public override void UpgradeEffect()
	{
		base.UpgradeEffect();
		switch(currentEffectLevel)
		{
			case 1:
				damagePerTick = 3f;
				duration = 5f;
				break;
			case 2:
				damagePerTick = 3f;
				duration = 7f;
				break;
			case 3:
				damagePerTick = 5f;
				duration = 7f;
				break;
			case 4:
				damagePerTick = 6f;
				duration = 7f;
				break;
			case 5:
				damagePerTick = 8f;
				duration = 8f;
				break;
		}
	}
}
