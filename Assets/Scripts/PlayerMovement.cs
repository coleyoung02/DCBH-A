using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 10.4f;

    public float dashSpeed = 20.0f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1.0f;

    private float dashTime;
    private float dashCooldownTime;
    private bool isDashing;

    void Start()
    {
        dashTime = 0;
        dashCooldownTime = 0;
        isDashing = false;
    }

    void Update()
    {
        if (!GameManager.EnablePlayerInput)
        {
            return;
        }

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

        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= currentSpeed * Time.deltaTime;
        }

        transform.position = pos;

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
