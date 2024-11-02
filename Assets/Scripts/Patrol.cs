using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class Patrol : MonoBehaviour, IBehaviour
{
    public Action OnStateChanged {get; set;}
    [SerializeField] Transform[] _patrolPoints;
    [SerializeField] float _speed = 1f;
    NavMeshAgent navMeshAgent;

    Transform _target;
    int _targetIndex = 0;

    public bool IsActive => true;
    
    void Start() 
    {
        _target = _patrolPoints[_targetIndex];
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.speed = _speed;
        navMeshAgent.SetDestination(_target.position);

    }
    public void Tick()
    {
        if (navMeshAgent.speed !=_speed)
            navMeshAgent.speed = _speed;
        if(Vector3.Distance(transform.position, _target.position) < 1f)
        {
            _targetIndex++;
            if (_targetIndex >= _patrolPoints.Length)
            {
                _targetIndex = 0;
            }
            _target = _patrolPoints[_targetIndex];
            navMeshAgent.SetDestination(_target.position);

        }
        if (navMeshAgent.velocity.magnitude > 0.1f) // A small threshold to avoid jitter
        {
            // Calculate the rotation needed to face the movement direction

            Vector3 direction = navMeshAgent.velocity.normalized; // Get the direction of movement
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction); // Create a rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f); // Smoothly rotate
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }
}
