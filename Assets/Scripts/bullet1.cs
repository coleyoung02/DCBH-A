using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    public int damage = 10;

    public void SetDirection(Vector3 direction)
    {
        this.transform.rotation = Quaternion.LookRotation(direction.normalized);
    }

    void Update()
    {
        transform.position += this.transform.up * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Projectile"))
        {
            return;
        }
        UnityEngine.Debug.Log("trigger entered with: " + other.name);
        if (other.CompareTag("Player"))
        {
            PlayerHealth stats = other.GetComponent<PlayerHealth>();
            stats.takeDamage(damage);
        }
        Destroy(gameObject);
    }
}
