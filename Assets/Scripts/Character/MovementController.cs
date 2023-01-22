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
    public GameObject training1Screen;
    public GameObject training2Screen;

    bool isInputBlocked = false;

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
        isGrounded = false;
        animator.SetBool("isGrounded", isGrounded);
    }

    public void BlockInput()
    {
        isInputBlocked = true;
    }

    public void UnblockInput()
    {
        isInputBlocked = false;
    }

    private void Update()
    {
        if (isDead == false)
        {
            if (Input.GetKeyDown("s") && isInputBlocked ==false)
            {
                moveSpeed = 0f;
                print(moveSpeed);
            }

            if (Input.GetKeyUp("s") && isInputBlocked == false)
            {
                moveSpeed = startSpeed;
                print(moveSpeed);
            }

            if (Input.GetKeyUp("d") && isInputBlocked == false)
            {
                Dying();
            }

            if (Input.GetKeyUp("j") && isInputBlocked == false)
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
        training1Screen.SetActive(false);
        training2Screen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Jumping()
    {
        StartCoroutine(JumpingProcess());
    }

    public void Dash()
    {
        StartCoroutine(DashProcess());
    }

    public bool IsDead()
    {
        return isDead;
    }

    IEnumerator JumpingProcess()
    {
        jumpSpeed = Mathf.Lerp(15,0,0.3f);
        isJumping = true;
        animator.SetBool("isJumping", isJumping);
        yield return new WaitForSeconds(0.3f);
        jumpSpeed = 0;
        isJumping = false;
        animator.SetBool("isJumping", isJumping);
    }

    IEnumerator DashProcess()
    {
        moveSpeed = startSpeed * 2.5f;
        animator.SetBool("isDashing", true);
        yield return new WaitForSeconds(0.2f);
        moveSpeed = startSpeed;
        animator.SetBool("isDashing", false);
    }
}
