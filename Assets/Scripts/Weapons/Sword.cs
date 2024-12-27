using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MeleeWeapon
{
    public ParticleSystem effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public override void Attack()
	{
		base.Attack();
        effect.Play();
	}

	public override void ApplyDamage()
	{
		base.ApplyDamage();
	}

	public override void EndAttack()
	{
		base.EndAttack();
	}
}
