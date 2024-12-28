using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingBar : MonoBehaviour
{
	public Slider slider;
	public float reduceSpeed;
	public float fadeSpeed;
	float fadeTimer;
	private float currentAlpha = 0f;
	private float value;
	private float maxValue;

	public float showTime;
	public float showTimer;
	public float delayTime;
	public float delayTimer;

	Transform cam;
	Image[] images;

	public bool isCoroutineRunning = false;
	// Start is called before the first frame update
	void Start()
	{
		cam = Camera.main.transform;
		images = GetComponentsInChildren<Image>();
	}

	// Update is called once per frame
	public virtual void Update()
	{
		transform.rotation = Quaternion.LookRotation(cam.forward, Vector3.up);
		UpdateBar();
	}

	public virtual void UpdateValueBar(float value, float maxValue)
	{
		showTimer = 0;
		delayTimer = delayTime;
		this.maxValue = maxValue;
		this.value = value;
	}

	public void UpdateBar()
	{
		// Giai đoạn fade in
		if (showTimer < showTime)
		{
			currentAlpha += Time.deltaTime * fadeSpeed;
			currentAlpha = Mathf.Clamp01(currentAlpha);

			foreach (Image image in images)
			{
				Color color = image.color;
				color.a = currentAlpha;
				image.color = color;
			}

			showTimer += Time.deltaTime; // Tăng thời gian hiển thị
		}
		// Giai đoạn delay
		else if (delayTimer > 0)
		{
			delayTimer -= Time.deltaTime; // Giảm thời gian delay
		}
		// Giai đoạn fade out
		else
		{
			currentAlpha -= Time.deltaTime * fadeSpeed;
			currentAlpha = Mathf.Clamp01(currentAlpha);

			foreach (Image image in images)
			{
				Color color = image.color;
				color.a = currentAlpha;
				image.color = color;
			}
		}
	}


}
