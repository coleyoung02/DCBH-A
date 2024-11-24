using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public float maxDistance = 15f;
   //public GameObject aoeEffectPrefab;
    //public float aoeDuration = 5f;

    private Vector3 startPoint;
    private Vector3 targetPoint;
    private bool hasLanded = false;

    void Start()
    {
        startPoint = transform.position;
        // Calculate direction to move towards the target point
        Vector3 direction = (targetPoint - startPoint).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = rotation;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public void Initialize(Vector3 target)
    {
        targetPoint = target;

    }

    void Update()
    {
        

        if (Vector3.Distance(startPoint, transform.position) >= maxDistance && !hasLanded)
        {
            Land();
        }
        // Check if we've reached the target point
        if (Vector3.Distance(transform.position, targetPoint) <= 0.1f)
        {
            Land();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().enemyHealth -= 50;
            
        }

        Land();

    }

    void Land()
    {
        Destroy(gameObject);
    }
}
