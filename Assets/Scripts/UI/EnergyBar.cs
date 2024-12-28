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
        //if (slider.value >= ma
        //xValue) slider.gameObject.SetActive(false);
        //else
        //{
        //    slider.gameObject.SetActive(true);
        //}

    }

	public override void UpdateValueBar(float value, float maxValue)
	{
        base.UpdateValueBar(value, maxValue);
		slider.value = value / maxValue;
	}

}
