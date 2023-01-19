using System.Collections;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float startSpeed;
    private float moveSpeed;

    private Rigidbody2D rb;
    private Animator animator;
    public GameObject deathSound;
    private bool isDead;

    public GameObject gameOverScreen;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveSpeed = startSpeed;
        isDead = false;
        gameOverScreen.SetActive(false);
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
        if (isDead == false)
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
    }

    public void Dying()
    {
        moveSpeed = 0.01f;
        isDead = true;
        animator.SetBool("isDead", true);
        print("Dying");
        deathSound.GetComponent<AudioSource>().Play();
        gameOverScreen.SetActive(true);
    }

    public bool IsDead()
    {
        return isDead;
    }
}
