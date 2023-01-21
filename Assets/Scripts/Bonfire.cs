using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    bool isActive = true;
    public GameObject bon1;
    public GameObject bon2;
    public GameObject bon3;
    public GameObject bon4;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && isActive==true)
        {
            collision.gameObject.GetComponent<MovementController>().Dying();
        }

        if (collision.gameObject.tag == "ice")
        {
            if (isActive)
            {
                Destroy(collision.gameObject);
            }
            BreakBonfire();                      
        }
        
    }
    public void BreakBonfire()
    {
        bon1.SetActive(false);
        bon2.SetActive(false);
        bon3.SetActive(false);
        bon4.SetActive(false);
        isActive = false;
        Debug.Log("bonfire deactivated");
        audioSource.Play();
    }
}
