using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{

    public Vector2 patrolPoint1;
    public Vector2 partrolPoint2;

    public float enemyHealth = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
