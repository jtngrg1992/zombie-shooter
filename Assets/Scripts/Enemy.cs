using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5;
    [SerializeField] bool isProvoked = false;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }

    }

    private void EngageTarget()
    {
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            // start attacking
            AttackTarget();
        }
        else
        {
            ChaseTarget();

        }
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.transform.position);
    }

    private void AttackTarget()
    {
        Debug.Log("attachking!");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0.4f, 0.5f);

        Gizmos.DrawSphere(transform.position, chaseRange);
    }
}
