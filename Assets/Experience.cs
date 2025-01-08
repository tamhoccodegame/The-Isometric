using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
	public float exp;
	private void OnTriggerEnter(Collider other)
	{
		PlayerLevel player = other.GetComponent<PlayerLevel>();
		if (player != null)
		{
			player.IncreaseExp(exp);
			Destroy(gameObject);
		}
	}
}
