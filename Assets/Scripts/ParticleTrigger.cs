using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
	// Phương thức này sẽ được gọi khi particle hệ thống va chạm với collider
	void OnParticleCollision(GameObject other)
	{
		if (other.GetComponent<EnemyHealth>())
		{
			// Xử lý sự kiện khi particle va chạm với game object "Target"
			other.GetComponent<EnemyHealth>().TakeDamage(10); // Giả sử đây là một đối tượng có phương thức TakeDamage
		}
	}
}


