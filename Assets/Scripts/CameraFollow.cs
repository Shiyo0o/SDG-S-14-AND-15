using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    
    // Smooth speed multiplier (higher numbers follow tighter)
    public float smoothSpeed = 10f;
    public float zOffset = -10f;

    void Start()
    {
        // Automatically finds your object named "Player"
        GameObject playerObject = GameObject.Find("Player");

        if (playerObject != null)
        {
            target = playerObject.transform;
            
            // Instantly snap to the player right when the game boots up
            transform.position = new Vector3(target.position.x, target.position.y, zOffset);
        }
    }

    // Changed to FixedUpdate so it syncs perfectly frame-for-frame with the player's Rigidbody2D!
    void FixedUpdate()
    {
        if (target != null)
        {
            // Calculate target positions
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, zOffset);
            
            // Smoothly blend positions without creating frame rate lag discrepancies
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.fixedDeltaTime);
        }
    }
}
