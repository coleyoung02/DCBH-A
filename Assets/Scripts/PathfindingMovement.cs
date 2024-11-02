using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathfindingMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(target.position);
        if (agent.velocity.magnitude > 0.1f) // A small threshold to avoid jitter
        {
            // Calculate the rotation needed to face the movement direction
            Vector3 direction = agent.velocity.normalized; // Get the direction of movement
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction); // Create a rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f); // Smoothly rotate
        }
    }
}
