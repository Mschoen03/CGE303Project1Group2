using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanController : MonoBehaviour
{
    public float speed = 5f;  // Walking speed
    public float acceleration = 10f; // Acceleration for smooth movement
    public float jumpForce = 10f; // Jumping force
    public Transform leftLeg, rightLeg; // Assign in the Inspector
    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation = RigidbodyInterpolation2D.Interpolate; // Smoother physics movement
    }

    void Update()
    {
        // Get player movement input
        moveInput = 0f;
        if (Input.GetKey(KeyCode.A)) moveInput = -1f; // Move left
        if (Input.GetKey(KeyCode.D)) moveInput = 1f;  // Move right

        // Smooth movement using acceleration
        rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, moveInput * speed, acceleration * Time.deltaTime), rb.velocity.y);

        // Flip character based on direction
        if (moveInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);

        // Animate legs when moving
        if (Mathf.Abs(rb.velocity.x) > 0.1f)
            AnimateLegs();
        else
            ResetLegs();

        // Jumping (only if on the ground)
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // Prevent double jumps
        }
    }

    void AnimateLegs()
    {
        float angle = Mathf.Sin(Time.time * 10) * 30f;
        leftLeg.localRotation = Quaternion.Euler(0, 0, angle);
        rightLeg.localRotation = Quaternion.Euler(0, 0, -angle);
    }

    void ResetLegs()
    {
        leftLeg.localRotation = Quaternion.Euler(0, 0, 0);
        rightLeg.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player touches the ground, allow jumping again
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
