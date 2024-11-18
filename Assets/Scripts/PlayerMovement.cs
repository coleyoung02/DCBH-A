using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private Rigidbody2D rb2d;
    private Vector2 moveDirection;
    private bool isDashing = false;
    private float dashTime;
    private float lastDashTime;

    void Start()
    {
        // Get the Rigidbody2D component
        rb2d = GetComponent<Rigidbody2D>();

        if (rb2d == null)
        {
            Debug.LogError("Rigidbody2D component not found on the GameObject.");
            return; // Exit the Start method if Rigidbody2D is not found
        }

        // Ensure Rigidbody2D settings are optimal for movement
        rb2d.gravityScale = 0f; // Disable gravity
        rb2d.drag = 0f; // Disable drag to avoid slowdowns
        rb2d.angularDrag = 0f; // Disable angular drag to avoid unnecessary rotations
    }

    void Update()
    {
        // Get input for movement (WASD)
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D or Arrow keys
        float vertical = Input.GetAxisRaw("Vertical");   // W/S or Arrow keys

        // Create a movement vector based on horizontal and vertical input
        moveDirection = new Vector2(horizontal, vertical).normalized;  // This handles both directions

        if (moveDirection.magnitude > 0)
        {
            //Debug.Log("Movement detected: " + moveDirection);
        }

        // Handle dashing
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time >= lastDashTime + dashCooldown)
        {
            isDashing = true;
            dashTime = Time.time + dashDuration;
            lastDashTime = Time.time;
            //Debug.Log("Dashing started!");
        }
    }

    void FixedUpdate()
    {
        if (rb2d == null)
        {
            return; // Ensure that we don't try to move if Rigidbody2D is missing
        }

        if (isDashing)
        {
            // Dash movement
            rb2d.MovePosition(rb2d.position + moveDirection * dashSpeed * Time.fixedDeltaTime);
            if (Time.time >= dashTime)
            {
                isDashing = false;
                //Debug.Log("Dash ended");
            }
        }
        else
        {
            // Regular movement
            rb2d.MovePosition(rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
