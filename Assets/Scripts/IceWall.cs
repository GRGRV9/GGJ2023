using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWall : MonoBehaviour
{
    private bool isActive = true;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isActive == true)
        {
            collision.gameObject.GetComponent<MovementController>().Dying();
        }

        if (collision.gameObject.tag == "earth")
        {
            BreakIcewall();
            Destroy(collision.gameObject);
        }

    }
    public void BreakIcewall()
    {
        animator.enabled = true;
        isActive = false;
        Debug.Log("icewall deactivated");
    }
}
