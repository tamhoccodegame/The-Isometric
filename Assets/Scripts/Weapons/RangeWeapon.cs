using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : Weapon
{
    public bool canApplyDamage = false;

    public HashSet<GameObject> hitEnemies = new HashSet<GameObject>();
    Vector3 initPosition;
    public float speed;
    private TrailRenderer trailRenderer;
    private Collider col;

    public override void Attack()
	{
        playerCombat.animator.SetTrigger("isAttack");
        
	}

    public override void ApplyDamage()
    {
        base.ApplyDamage();
        StartCoroutine(FlyCoroutine());
    }

    IEnumerator FlyCoroutine()
    {
        trailRenderer.enabled = true;
        col.enabled = true;

        Transform parent = transform.parent;
        transform.SetParent(null);

        float timer = attackCooldown / 2f;
        Vector3 direction = playerCombat.transform.forward;
        while (timer > 0)
        {
            
            direction.y = 0f;
            transform.position += direction * speed * Time.deltaTime;
            timer -= Time.deltaTime;
            yield return null;
        }

        timer = attackCooldown / 2f;

        while (Vector3.Distance(transform.position, parent.position) > 0.5f)
        {
            Vector3 direction2 = (playerCombat.transform.position - transform.position).normalized;
            direction2.y = 0;
            transform.position += direction2 * speed * Time.deltaTime;
            timer -= Time.deltaTime;
            yield return null;
        }

        transform.SetParent(parent, true);
        transform.localPosition = Vector3.zero;
        trailRenderer.enabled = false;
        col.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        initPosition = transform.position;
        weaponType = 2;
        trailRenderer = GetComponent<TrailRenderer>();
        col = GetComponent<Collider>();
        trailRenderer.enabled = false;
        col.enabled = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (!canApplyDamage) return;

    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if(enemyHealth != null )
        {
            enemyHealth.TakeDamage(damage);
            SpawnHitEffect(other.ClosestPoint(transform.position));
        }
    }

    protected override void SpawnHitEffect(Vector3 position)
    {
        base.SpawnHitEffect(position);
    }
}
