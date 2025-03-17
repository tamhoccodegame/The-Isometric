using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 currentPatrolPoint;

    private Animator animator;

    public enum EnemyState
    {
        Patrol,
        Chase,
        Attack,
    }

    public EnemyState state;
      
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Vector3 offset = new Vector3(Random.Range(5, 10), 0, Random.Range(5, 10));
        currentPatrolPoint = transform.position + offset;

        state = EnemyState.Patrol;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    public void ChangeState(EnemyState newState)
    {
		switch (state)
		{
			case EnemyState.Patrol:
                Patrol();
				break;
			case EnemyState.Chase:
                Chase();
				break;
			case EnemyState.Attack:
                Attack();
				break;
		}

        state = newState;
	}

    void Patrol()
    {
        bool isReached = Vector3.Distance(transform.position, currentPatrolPoint) < 0.5f;

        if (isReached)
        {
			SetNewPatrolPoint();
		}

        agent.SetDestination(currentPatrolPoint);

	}

	void SetNewPatrolPoint()
	{
        animator.SetTrigger("isAttack");
		// Tạo điểm tuần tra ngẫu nhiên trong bán kính
		Vector3 randomDirection = Random.insideUnitSphere * 20;
		randomDirection += transform.position;

		// Tìm điểm có thể đi được trên NavMesh
		NavMeshHit hit;
		if (NavMesh.SamplePosition(randomDirection, out hit, 20, NavMesh.AllAreas))
		{
			currentPatrolPoint = hit.position;
		}
	}

	void Chase()
    {

    }

    void Attack()
    {

    }

    public void ApplyDamage()
    {

    }

    public void SpawnEffect()
    {

    }

    public void EndAttack()
    {

    }
}
