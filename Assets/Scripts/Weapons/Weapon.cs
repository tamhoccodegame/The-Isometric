using Photon.Pun;
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
    public int weaponType;

    public GameObject hitEffect;


    public float attackCooldown;
    public float attackTimer;

    public GameObject weaponOnGroundPrefab;

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

    protected virtual void SpawnHitEffect(Vector3 position)
    {
        GameObject effect = Instantiate(hitEffect, position, Quaternion.identity);
        Destroy(effect, 2f);
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
        if (activeEffect.Length > 0)
        {
            foreach (BaseEffect effect in activeEffect)
            {
                effect.ApplyEffect(enemy);
            }
        }
    }

    public void UpgradeEffect(Type effect)
    {
        if (GetComponent(effect) == null)
        {
            AddEffect(effect);
            return;
        }

        if (effect == typeof(BleedingEffect))
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
        slashEffectSpawnPoint = playerCombat.meleeEffectSpawnPoint;
    }

    protected virtual void Update()
    {
        //if (Input.GetKeyDown(KeyCode.KeypadPlus))
        //{
        //    AddEffect(new BleedingEffect());
        //}
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            UpgradeEffect(typeof(BleedingEffect));
        }


        if (attackTimer <= attackCooldown)
        {
            attackTimer += Time.deltaTime;
        }


    }

    public void DropWeapon()
    {
        var droppedWeapon = PhotonNetwork.Instantiate(weaponOnGroundPrefab.name, playerCombat.transform.position, weaponOnGroundPrefab.transform.rotation);
        DestroyWeaponInHand();
    }

    void DestroyWeaponInHand()
    {
        PhotonView view = GetComponent<PhotonView>();
        if (view == null) return;
        view.TransferOwnership(PhotonNetwork.LocalPlayer);
        view.RPC("RPC_DestroyWeaponInHand", RpcTarget.AllBuffered);
    }

    [PunRPC]
    public void RPC_DestroyWeaponInHand()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
