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
    GameObject player;
    Chase chase;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        parentObject = transform.parent.gameObject;
        navMesh = parentObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        chase = parentObject.GetComponent<Chase>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.identity;
        //Fix the next section
        velocity = navMesh.velocity.x;
        if(chase.sees !=null && chase.sees != player.transform)
        {
            velocity = navMesh.velocity.x;
        }
        else
        {
            velocity = player.transform.position.x - this.transform.position.x;

        }
        if ((velocity>0 && !spriteRenderer.flipX) || (velocity < 0 && spriteRenderer.flipX))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        this.transform.rotation = Quaternion.identity;


    }
}
