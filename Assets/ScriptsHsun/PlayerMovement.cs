using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;

    private float dashTime;
    private float dashCooldownTime;
    private bool isDashing;
    private Rigidbody2D rb;

    void Start()
    {
        dashTime = 0;
        dashCooldownTime = 0;
        isDashing = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //cooldown countdown
        if (dashCooldownTime > 0)
        {
            dashCooldownTime -= Time.deltaTime;
        }

        // Start dash if LeftShift is pressed and cooldown has finished
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTime <= 0)
        {
            isDashing = true;
            dashTime = dashDuration;
            dashCooldownTime = dashCooldown;
        }

        // Set movement speed based on dash state lol had to gpt this 
        float currentSpeed;
        if (isDashing)
        {
            currentSpeed = dashSpeed;
        }
        else
        {
            currentSpeed = speed;
        }
        //float currentSpeed = isDashing ? dashSpeed : speed; apparently this also works cuz its a simplified if-else statement


        // Calculate movement direction
        Vector2 movement = Vector2.zero;
        if (Input.GetKey("w"))
        {
            movement.y += 1;
        }
        if (Input.GetKey("s"))
        {
            movement.y -= 1;
        }
        if (Input.GetKey("d"))
        {
            movement.x += 1;
        }
        if (Input.GetKey("a"))
        {
            movement.x -= 1;
        }

        // Apply velocity to Rigidbody2D
        rb.velocity = movement.normalized * currentSpeed;

        // Dash duration countdown
        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0)
            {
                isDashing = false;
            }
        }
    }
}

