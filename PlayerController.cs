using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // gives movement speed and jumping force
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float jumpForce = 8f;

    [Header("Ground Check")]
    public bool isGrounded = false;

    [Header("Visual")]
    public Transform playerVisual; // is given a child object with the OC Sprite

    private Rigidbody rb;
    private float visualScaleX;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Stores the original scale so that flipping doesn't break size
        if (playerVisual != null)
        {
            visualScaleX = Mathf.Abs(playerVisual.localScale.x);
        }
    }

    void Update()
    {
        float moveInput = 0f;
        // Movement for Left and Right "A and D"
        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
        }
        // Moves the player within its velocity.
        Vector3 velocity = rb.linearVelocity;
        velocity.x = moveInput * moveSpeed;
        rb.linearVelocity = velocity;
        // Allows the player to jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        HandleFlip(moveInput);
    }
    // FLips sprite depending on movement
    void HandleFlip(float moveInput)
    {
        if (playerVisual == null) return;

        Vector3 scale = playerVisual.localScale;

        // PNG faces LEFT by default
        if (moveInput < 0)
        {
            scale.x = visualScaleX;      // keep normal for left
            playerVisual.localScale = scale;
        }
        else if (moveInput > 0)
        {
            scale.x = -visualScaleX;     // flip for right
            playerVisual.localScale = scale;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
        // Detects the collider landing on the ground
    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
