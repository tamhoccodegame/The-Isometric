﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingBar : MonoBehaviour
{
	public Vector3 offset;
	public Slider slider;
	public float reduceSpeed;
	public float fadeSpeed;
	float fadeTimer;
	Transform cam;
	Image[] images;
	// Start is called before the first frame update
	void Start()
	{
		cam = Camera.main.transform;
		images = GetComponentsInChildren<Image>();
	}

	// Update is called once per frame
	void Update()
	{
		transform.rotation = Quaternion.LookRotation(cam.forward, Vector3.up);
	}

	public virtual void UpdateBar(float value, float maxValue)
	{
		StopAllCoroutines();
		StartCoroutine(ShowBar());
	}

	IEnumerator ShowBar()
	{
		// Fade in
		float currentFadeTime = 0f;
		while (currentFadeTime < fadeSpeed)
		{
			foreach (Image i in images)
			{
				Color color = i.color;
				color.a = Mathf.Lerp(0f, 1f, currentFadeTime / fadeSpeed); // Tăng dần alpha
				i.color = color;
			}
			currentFadeTime += Time.deltaTime;
			yield return null;
		}

		// Đợi một khoảng thời gian
		yield return new WaitForSeconds(2f);

		// Fade out
		currentFadeTime = 0f;
		while (currentFadeTime < fadeSpeed)
		{
			foreach (Image i in images)
			{
				Color color = i.color;
				color.a = Mathf.Lerp(1f, 0f, currentFadeTime / fadeSpeed); // Giảm dần alpha
				i.color = color;
			}
			currentFadeTime += Time.deltaTime;
			yield return null;
		}
	}

}