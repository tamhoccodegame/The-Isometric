using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Effect[] effects;
    public float damage;
	public Transform slashEffectSpawnPoint;
    public int currentSkillLevel;
	protected PlayerCombat playerCombat;

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

    public void AddEffect(Type effect)
    {
        gameObject.AddComponent(effect);
    }

    public void ApplyEffect(GameObject enemy)
    {
        BaseEffect[] activeEffect = GetComponents<BaseEffect>();
        if(activeEffect.Length > 0)
        {
            foreach(BaseEffect effect in activeEffect)
            {
                effect.ApplyEffect(enemy);
            }
        }
    }

    public void UpgradeEffect(Type effect)
    {
        if(GetComponent(effect) == null)
        {
            AddEffect(effect);
            return;
        }

        if(effect == typeof(BleedingEffect))
        {
            GetComponent<BleedingEffect>().UpgradeEffect();
        }
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

	protected virtual void Update()
	{
        //if (Input.GetKeyDown(KeyCode.KeypadPlus))
        //{
        //    AddEffect(new BleedingEffect());
        //}
        if(Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            UpgradeEffect(typeof(BleedingEffect));
        }
	}
}
