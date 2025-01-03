using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseEffect : MonoBehaviour
{
    protected int maxEffectLevel;
    protected int currentEffectLevel;

    protected virtual void Start()
    {
        currentEffectLevel = 1;
        maxEffectLevel = 5;
    }
    public abstract void ApplyEffect(GameObject target);
    public abstract void RemoveEffect(GameObject target);
    public virtual void UpgradeEffect()
    {
        currentEffectLevel++;
        currentEffectLevel = Mathf.Min(currentEffectLevel, maxEffectLevel);
    }
}
