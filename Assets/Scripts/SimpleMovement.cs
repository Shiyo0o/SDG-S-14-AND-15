using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    
    // Reference to the Animator component
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. Gather raw keyboard inputs
        movementInput.x = 0;
        movementInput.y = 0;

        if (Input.GetKey(KeyCode.D)) movementInput.x = 1;
        else if (Input.GetKey(KeyCode.A)) movementInput.x = -1;

        if (Input.GetKey(KeyCode.W)) movementInput.y = 1;
        else if (Input.GetKey(KeyCode.S)) movementInput.y = -1;

        // 2. CRUCIAL: Determine if the player is actively pressing a key
        bool isMoving = (movementInput.x != 0 || movementInput.y != 0);
        animator.SetBool("isMoving", isMoving);

        // 3. ONLY update MoveX and MoveY if the player is actively moving!
        // This keeps them locked on the last direction when you let go of the keys.
        if (isMoving)
        {
            animator.SetFloat("MoveX", movementInput.x);
            animator.SetFloat("MoveY", movementInput.y);
        }
    }

    void FixedUpdate()
    {
        // Normalize movement so diagonal walking isn't faster
        rb.MovePosition(rb.position + movementInput.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
