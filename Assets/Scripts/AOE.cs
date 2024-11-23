using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AOE : MonoBehaviour
{

    public float damagePerSecond = 10f;
    public float duration = 5f;

    void Start()
    {
        Destroy(gameObject, duration);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("testing1234");
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Apply damage over time to enemies in the area
            other.GetComponent<Enemy>().TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}
