using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public LevelUI levelUI;
    public SkillUpgradeUI skillUpgradeUI;

    public float[] expToLevelUp;
    public float currentExp = 0;
    public int currentLevel = 1;

    public Action<float, int> onExpChange;
    public Action onLevelUp;

	private void Awake()
	{
        levelUI.SetPlayerLevel(this);
        skillUpgradeUI.SetPlayerLevel(this);
	}

	// Start is called before the first frame update
	void Start()
    {
		onExpChange?.Invoke(currentExp, currentLevel);
	}

	// Update is called once per frame
	void Update()
    {
        
    }

    [ContextMenu("IncreaseExp")]
    public void InreaseExp50()
    {
        IncreaseExp(50);
    }

    public void IncreaseExp(float exp)
    {
        currentExp += exp;
        if(currentExp >= expToLevelUp[currentLevel - 1])
        {
            if (currentLevel < expToLevelUp.Length)
			{
				currentExp = currentExp - expToLevelUp[currentLevel - 1];
				currentLevel++;
                onLevelUp?.Invoke();
            }
            else currentExp = expToLevelUp[currentLevel - 1];
        }
        onExpChange?.Invoke(currentExp / expToLevelUp[currentLevel - 1], currentLevel);
    }

}
