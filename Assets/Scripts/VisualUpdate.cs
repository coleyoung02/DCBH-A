using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

public class VisualUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    float velocity;
    NavMeshAgent navMesh;
    GameObject parentObject;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        parentObject = transform.parent.gameObject;
        navMesh = parentObject.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.identity;
        //Fix the next section
        velocity = navMesh.velocity.x;
        //UnityEngine.Debug.Log(velocity);
        if ((velocity>0 && spriteRenderer.flipX) || (velocity < 0 && !spriteRenderer.flipX))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

    }
}
