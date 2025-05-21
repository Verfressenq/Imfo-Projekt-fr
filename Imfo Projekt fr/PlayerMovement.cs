using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player object
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get player input for horizontal and vertical movement
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Arrow keys
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Arrow keys

        // Move the player
        Vector2 movement = new Vector2(moveX, moveY).normalized * moveSpeed;
        rb.velocity = movement;
    }
}