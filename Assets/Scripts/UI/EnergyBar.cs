using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : FloatingBar
{
    private float value;
    private float maxValue;
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //slider.maxValue = maxValue;
        //slider.value = value / maxValue;
        //if (slider.value >= maxValue) slider.gameObject.SetActive(false);
        //else
        //{
        //    slider.gameObject.SetActive(true);
        //}

    }

	public override void UpdateBar(float value, float maxValue)
	{
		slider.value = value / maxValue;
        if(isCoroutineRunning) return;
		StartCoroutine(ShowBar(showTime));
	}

}
