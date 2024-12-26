using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float damage;

    public abstract void Attack();
    public virtual void Reload()
    {
        Debug.Log("Reloading");
    }
}
