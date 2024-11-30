using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Vector3 patrolPoint1;
    public Vector3 patrolPoint2;
    public float enemyHealth = 25;
    public float enemyMaxHealth = 25;
    public Camera camera;

    private EnemyHealth healthBar;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        healthBar = gameObject.GetComponentInChildren<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        healthBar.UpdateHealthBar(enemyHealth, enemyMaxHealth);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    
}
