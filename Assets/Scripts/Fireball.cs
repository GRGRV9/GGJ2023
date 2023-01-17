using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        StartCoroutine(BlowTimer());
    }

    IEnumerator BlowTimer()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
