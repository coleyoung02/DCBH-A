using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 moveDirection;
   
  


    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction;
        moveDirection.z = 0;
        moveDirection = moveDirection.normalized;
    }

    private void Start()
    {
        
        
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("WHAT THE HELL");
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(5); 

        }
        Destroy(gameObject);
    }

}
