using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Weapon weapon;
    public LayerMask enemyLayer;
    public bool canApplyDamage = false;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & enemyLayer) != 0 && canApplyDamage)
        {
            Vector3 closetPoint = other.ClosestPoint(transform.position);
            GameObject effect = Instantiate(weapon.hitEffect, closetPoint, Quaternion.identity);
            Destroy(effect, 2f);
        }
    }
}
