using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualUpdate : MonoBehaviour
{
    // Start is called before the first frame update
    float velocity;
    NavMesh navmesh;
    GameObject parent;
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
        velocity = agent.velocity.x;
        if ((velocity>0 && spriteRenderer.flipX) || (velocity < 0 && !spriteRenderer.flipX))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

    }
}
