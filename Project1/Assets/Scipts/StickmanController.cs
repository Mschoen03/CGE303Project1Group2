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

/* This is a refrence to the platformer script prototype
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if(horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
*/




