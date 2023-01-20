using System.Collections;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float startSpeed;
    private float moveSpeed;
    private float jumpSpeed;

    private Rigidbody2D rb;
    private Animator animator;
    public GameObject deathSound;
    
    private bool isDead;
    private bool isJumping;
    private bool isGrounded;

    public GameObject gameOverScreen;

    void Start()
    {
        isJumping = false;
        isGrounded = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveSpeed = startSpeed;
        jumpSpeed = 0;
        isDead = false;
        gameOverScreen.SetActive(false);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed * moveSpeed, jumpSpeed * moveSpeed);

        animator.SetFloat("speed", moveSpeed);
        Debug.Log(isGrounded);
        isGrounded = false;
        animator.SetBool("isGrounded", isGrounded);
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

            if (Input.GetKeyUp("j"))
            {
                Jumping();
            }
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("isGrounded", isGrounded);
            Debug.Log(collision.gameObject.name);
        }
    }

    public void Dying()
    {
        moveSpeed = 0.01f;
        isDead = true;
        animator.SetBool("isDead", isDead);
        print("Dying");
        deathSound.GetComponent<AudioSource>().Play();
        gameOverScreen.SetActive(true);
    }

    public void Jumping()
    {
        StartCoroutine(JumpingProcess());
    }

    public bool IsDead()
    {
        return isDead;
    }

    IEnumerator JumpingProcess()
    {
        jumpSpeed = Mathf.Lerp(10,0,0.32f);
        isJumping = true;
        animator.SetBool("isJumping", isJumping);
        yield return new WaitForSeconds(0.32f);
        jumpSpeed = 0;
        isJumping = false;
        animator.SetBool("isJumping", isJumping);
    }
}
