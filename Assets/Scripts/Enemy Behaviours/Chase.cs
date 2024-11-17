using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[DisallowMultipleComponent]
public class Chase : MonoBehaviour, IBehaviour
{
    public Action OnStateChanged {get; set;}

    [SerializeField] float _speed = 3f;
    [SerializeField] LayerMask ignore;
    //bool in_range = false;
    bool _isActive = false;
    bool seen = false;
    public bool IsActive => _isActive;
    Transform visual;

    NavMeshAgent navMeshAgent;

    //test stuff
    public float distance;
    public float angle;
    public Transform sees;
    private GameObject player;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        visual = this.transform;
        player = GameObject.FindWithTag("Player");
    }
    public void Tick()
    {
        
        //if (!_isActive || !in_range) return;
        navMeshAgent.speed = _speed;
        navMeshAgent.destination = player.transform.position;

        if (navMeshAgent.velocity.magnitude > 0.1f) // A small threshold to avoid jitter
        {
            // Calculate the rotation needed to face the movement direction

            Vector3 direction = navMeshAgent.velocity.normalized; // Get the direction of movement
            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction); // Create a rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f); // Smoothly rotate
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    void Update()
    {
        //if (in_range) return;
        // Get the player's forward direction
        Vector2 enemyDirection = transform.up; // Assuming the player's facing direction is up in 2D

        // Get the enemy's position
        Vector2 playerPosition = player.transform.position;

        // Calculate the direction to the enemy
        Vector2 directionToEnemy = (playerPosition - (Vector2)transform.position).normalized;

        // Calculate the angle between the player's direction and the direction to the enemy
        float view_angle = Vector2.Angle(enemyDirection, directionToEnemy);
        //Debug.Log(view_angle);
        if (view_angle <= angle && !seen)
        {
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, (player.transform.position - this.transform.position).normalized, distance, ~ignore);
            if (hit.collider != null)
            {
                sees = hit.collider.transform;
                if (hit.transform != null && hit.transform.CompareTag("Player"))
                {
                    _isActive = true;
                    seen = true;
                    OnStateChanged.Invoke();

                }
            }
        }
        //if (dist <= distance && _target != null)
        //{
        //    _target = player.transform;
        //    _isActive = false;
        //    seen = false;
        //    OnStateChanged.Invoke();
        //}
    }

}
