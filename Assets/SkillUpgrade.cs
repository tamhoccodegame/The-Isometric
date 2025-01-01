using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillData
{
    public Sprite skillSprite;
    public SkillUpgrade.UpgradeSkillType upgradeSkillType;
}

public class SkillUpgrade : MonoBehaviour
{
    public SkillUpgradeUI skillUpgradeUI;
    public PlayerCombat playerCombat;

    public List<SkillData> allSkills;

    public enum UpgradeSkillType
    {
        Effect,
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

    public void UpgradeSkill(SkillData skillData)
    {
        switch (skillData.upgradeSkillType)
        {
            case UpgradeSkillType.Effect:
                break;
            case UpgradeSkillType.WeaponSkill:
                playerCombat.currentWeapon.UpgradeSkillLevel();
                break;
            case UpgradeSkillType.Health:
                break;
        } 
    }
}
