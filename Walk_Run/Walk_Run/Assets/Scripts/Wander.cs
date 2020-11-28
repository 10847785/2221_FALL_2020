using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    public Transform target;
    private NavMeshAgent agent;
    private float timer;

    private float distance;
    private Vector3 direction;

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    private void Start()
    {
        distance = Vector3.Distance(target.position, transform.position);
    }

    private void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if (timer >= wanderTimer)
        {
         //   Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
         //   agent.SetDestination(newPos);
          //  timer = 0;
        }
    }

  /*  public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 ranDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    } */
}
