using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Molotov1 : MonoBehaviour
{
    public float speed = 10f;
    public float maxDistance = 15f;
    public GameObject aoeEffectPrefab;
    public float aoeDuration = 5f;

    private Vector3 startPoint;
    private Vector3 targetPoint;
    private bool hasLanded = false;

    void Start()
    {
        startPoint = transform.position;
        // Calculate direction to move towards the target point
        Vector3 direction = (targetPoint - startPoint).normalized;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public void Initialize(Vector3 target)
    {
        targetPoint = target;
        
    }

    void Update()
    {
        float move = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, move);

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
        if (!hasLanded)
        {
            Land();
        }
    }

    void Land()
    {
        hasLanded = true;
        // Stop movement
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // Spawn the AOE effect
        Instantiate(aoeEffectPrefab, transform.position, Quaternion.identity);
        // Destroy the Molotov object
        Destroy(gameObject);
    }
}
