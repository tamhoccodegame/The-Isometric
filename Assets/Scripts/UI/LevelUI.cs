using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    private PlayerLevel playerLevel;

    public Slider expBar;
    public TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        playerLevel.onExpChange += OnExpChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnExpChange(float expValue, int level)
    {
        expBar.value = expValue;
        levelText.text = "Level " + level.ToString("00");
    }

    public void SetPlayerLevel(PlayerLevel _playerLevel)
    {
        playerLevel = _playerLevel;
    }

}
