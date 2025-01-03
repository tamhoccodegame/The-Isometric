using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillButton
{
    public Sprite skillSprite;
    public SkillUpgrade.UpgradeSkillType upgradeSkillType;
}

public class SkillUpgrade : MonoBehaviour
{
    public SkillUpgradeUI skillUpgradeUI;
    public PlayerCombat playerCombat;

    public List<SkillButton> allSkills;

    public enum UpgradeSkillType
    {
        BleedingEffect,
        WeaponSkill,
        Health,
    }

	private void Awake()
	{
		skillUpgradeUI.SetSkillUpgrade(this);
	}
	// Start is called before the first frame update
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpgradeSkill(SkillButton skillData)
    {
        switch (skillData.upgradeSkillType)
        {
            case UpgradeSkillType.BleedingEffect:
                playerCombat.currentWeapon.UpgradeEffect(typeof(BleedingEffect));
                break;
            case UpgradeSkillType.WeaponSkill:
                playerCombat.currentWeapon.UpgradeSkillLevel();
                break;
            case UpgradeSkillType.Health:
                break;
        } 
    }
}
