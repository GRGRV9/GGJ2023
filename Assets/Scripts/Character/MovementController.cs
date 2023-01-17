using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float startSpeed;
    private float moveSpeed;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveSpeed = startSpeed;
    }

    void FixedUpdate()
    {
        float moveX = moveSpeed;
        float moveY = 0;

        rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        animator.SetFloat("speed", moveSpeed);
    }

    private void Update()
    {

        if (Input.GetKeyDown("s"))
        {
            moveSpeed = 0f;
            print(moveSpeed);
        }

        if (Input.GetKeyUp("s"))
        {
            moveSpeed = startSpeed;
            print(moveSpeed);
        }

        if (Input.GetKeyUp("d"))
        {
            Dying();
        }
    }

    public void Dying()
    {
        moveSpeed = 0.01f;
        animator.SetBool("isDead", true);
        print("Dying");
    }
}
