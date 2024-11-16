using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    [SerializeField] float speed = 5f;

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
}
