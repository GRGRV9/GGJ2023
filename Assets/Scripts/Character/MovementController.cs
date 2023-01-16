using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveX = moveSpeed;
        float moveY = 0;

        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
    }
}
