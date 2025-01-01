using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgradeUI : MonoBehaviour
{
    private PlayerLevel playerLevel;
    private SkillUpgrade skillUpgrade;

    public GameObject skillUpgradePanel;
    public Button[] skillButtons;

    public int skillUpgradeTimes = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerLevel.onLevelUp += UpdateSkillUpgradeTimes;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSkillUpgradeTimes()
    {
		skillUpgradeTimes++;
        ShowSkillUpgrade();
	}
    void ShowSkillUpgrade()
    {
        skillUpgradePanel.SetActive(true);

        //Random 3 kỹ năng
        SkillData[] selectedSkills = RandomSkill(3);

        //Cập nhật UI
        for (int i = 0; i < skillButtons.Length; i++)
        {
            skillButtons[i].GetComponent<Image>().sprite = selectedSkills[i].skillSprite;

            int index = i;
            skillButtons[i].onClick.RemoveAllListeners();
            skillButtons[i].onClick.AddListener(() => UpgradeSkill(selectedSkills[index]));
        }
    }

    void UpgradeSkill(SkillData skillData)
    {
        skillUpgradeTimes--;
        skillUpgradeTimes = Mathf.Max(skillUpgradeTimes, 0);
        if (skillUpgradeTimes <= 0)
            skillUpgradePanel.SetActive(false);
        else
        {
            ShowSkillUpgrade();
        }
        skillUpgrade.UpgradeSkill(skillData);
    }

    SkillData[] RandomSkill(int count)
    {
        List<SkillData> randomSkills = new List<SkillData>();
        List<SkillData> avaliableSkills = new List<SkillData>(skillUpgrade.allSkills);

        while(randomSkills.Count < count && avaliableSkills.Count > 0)
        {
            int randomIndex = Random.Range(0, avaliableSkills.Count);
            randomSkills.Add(avaliableSkills[randomIndex]);
            avaliableSkills.RemoveAt(randomIndex);
        }

        return randomSkills.ToArray();
    }

    public void SetPlayerLevel(PlayerLevel _playerLevel)
    {
        playerLevel = _playerLevel;
    }

    public void SetSkillUpgrade(SkillUpgrade _skillUpgrade)
    {
        skillUpgrade = _skillUpgrade;
    }
}
