using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    public LayerMask solidObjectsLayer; 
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movementInput.x = 0;
        movementInput.y = 0;

        if (Input.GetKey(KeyCode.D)) movementInput.x = 1;
        else if (Input.GetKey(KeyCode.A)) movementInput.x = -1;

        if (Input.GetKey(KeyCode.W)) movementInput.y = 1;
        else if (Input.GetKey(KeyCode.S)) movementInput.y = -1;

        bool isMoving = (movementInput.x != 0 || movementInput.y != 0);
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            animator.SetFloat("MoveX", movementInput.x);
            animator.SetFloat("MoveY", movementInput.y);
        }
    }

    void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            Vector2 moveDirection = movementInput.normalized;
            
            // EMERGENCY BYPASS: Moving the player directly without checking walls
            Vector3 targetPosition = rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(targetPosition);
        }
    }

    private bool IsWalkable(Vector2 direction, float distance)
    {
        // Temporarily returns true always until you fix your Unity editor layer
        return true; 
    }
}
