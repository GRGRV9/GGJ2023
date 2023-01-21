using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneWall : MonoBehaviour
{
    private bool isActive = true;
    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isActive == true)
        {
            collision.gameObject.GetComponent<MovementController>().Dying();
        }

        if (collision.gameObject.tag == "fire")
        {
            if (isActive)
            {
                Destroy(collision.gameObject);
            }
            BreakStonewall();                    
        }
    }
    public void BreakStonewall()
    {
        animator.enabled = true;
        isActive = false;
        Debug.Log("icewall deactivated");
        audioSource.Play();
    }
}
