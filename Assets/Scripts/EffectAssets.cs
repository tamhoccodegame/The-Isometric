using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect
{
	public string effectName;
	public GameObject effectPrefab;
}

public class EffectAssets : MonoBehaviour
{
	public Effect[] effects;
	private void Start()
	{

	}
}
