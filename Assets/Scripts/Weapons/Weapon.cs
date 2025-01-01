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
    public int currentSkillLevel;
	protected PlayerCombat playerCombat;

	private void Start()
	{
		
	}

    public virtual void UseSkill(int currentSkillLevel)
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

    public void UpgradeSkillLevel()
    {
        currentSkillLevel++;
        playerCombat.currentWeaponUpgradeSkill = currentSkillLevel;
    }

	public void SetPlayerCombat(PlayerCombat _playerCombat)
    {
        playerCombat = _playerCombat;
    }
}
