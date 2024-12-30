using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Effect[] effects;
    public float damage;
	public Transform slashEffectSpawnPoint;
    public Vector3 leftSlashRotation;
    public Vector3 rightSlashRotation;
	protected PlayerCombat playerCombat;
    public enum SkillType
    {
		None,
		DoubleSlash,
		Whirlwind,
		DashAttack,
	}

    public SkillType currentSkillType;

	private void Start()
	{
		
	}

    public virtual void UseSkill()
    {

    }
	public void SpawnEffect(string effectName)
    {
        Effect effect = effects.FirstOrDefault(e => e.effectName == effectName);

        if (effect != null)
        {
            var go = Instantiate(effect.effectPrefab, slashEffectSpawnPoint.position, slashEffectSpawnPoint.rotation, slashEffectSpawnPoint);
            go.transform.localRotation = effect.effectPrefab.transform.rotation;
            go.transform.localPosition = effect.effectPrefab.transform.position;
        }
    }

	public abstract void Attack();
    public virtual void Reload()
    {
        Debug.Log("Reloading");
    }

    public virtual void ApplyDamage()
    {

    }

    public virtual void EndAttack()
    {

	}

    public void SetPlayerCombat(PlayerCombat _playerCombat)
    {
        playerCombat = _playerCombat;
    }
}
