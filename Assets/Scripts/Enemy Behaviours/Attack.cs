using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour, IBehaviour
{
    public Action OnStateChanged {get; set;}

    bool isActive = false;
    public bool IsActive => isActive;
    [SerializeField] float fireCooldown;
    float currentFireCooldown;
    [SerializeField] GameObject bullet;
    [SerializeField] float _attackRange = 5f, _speed = 3f;
    [SerializeField] LayerMask ignore;

    Transform _target = null;
    Transform visual;
    Chase chase;
    NavMeshAgent navMesh;
    Animator animator;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        visual = this.transform;
        _target = GameObject.FindWithTag("Player").transform;
        chase = GetComponent<Chase>();
        animator = GetComponentInChildren<Animator>();
    }
    public void Tick()
    {
        UnityEngine.Debug.Log(currentFireCooldown);
        navMesh.speed = _speed;
        navMesh.destination = _target.position + (transform.position-_target.position).normalized*2f;

        Vector3 direction = (_target.position-transform.position).normalized; // Get the direction of movement
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction); // Create a rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f); // Smoothly rotate
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        UnityEngine.Debug.Log(currentFireCooldown);
        if (currentFireCooldown <= 0)
        {
            animator.SetTrigger("Attack");
            GameObject bullet_instance = Instantiate(bullet, this.transform.position, this.transform.rotation);
            currentFireCooldown = fireCooldown;
            UnityEngine.Debug.Log("fire");
        }
    }


    void Update() 
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, (_target.transform.position - this.transform.position).normalized, _attackRange*2, ~ignore);

        if (Vector3.Distance(transform.position, _target.position) < _attackRange && chase.IsActive == true &&
            hit.collider != null && 
            hit.transform != null && 
            hit.transform.CompareTag("Player"))
        {
            if (isActive == false)
            {
                isActive = true;
                OnStateChanged.Invoke();
            }

        }
        else
        {
            if(isActive == true)
            {
                isActive = false;
                visual.localEulerAngles = Vector3.zero;
                OnStateChanged.Invoke();
            }
        }
        if(currentFireCooldown > 0) {
            currentFireCooldown -= Time.deltaTime;    
        }
    }
}
