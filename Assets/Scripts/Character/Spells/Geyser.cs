using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    private bool isActive;

    private void Start()
    {
        isActive = true;
        StartCoroutine(DestroyTimer());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isActive == true)
        {
            collision.gameObject.GetComponent<MovementController>().Jumping();
        }
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
