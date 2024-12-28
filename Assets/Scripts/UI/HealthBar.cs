using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : FloatingBar
{
	private float target = 1;
    // Update is called once per frame
    public override void Update()
    {
		base.Update();
		slider.value = Mathf.MoveTowards(slider.value, target, reduceSpeed * Time.deltaTime);
	}

	public override void UpdateValueBar(float value, float maxValue)
	{
		base.UpdateValueBar(value, maxValue);
		//base.StopAllCoroutines();
		target = value / maxValue;
	}
}
