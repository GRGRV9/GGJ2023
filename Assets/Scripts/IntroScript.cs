using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public GameObject introCamera;
    public GameObject charCamera;
    public GameObject iceWall;

    // Start is called before the first frame update
    void Start()
    {
        introCamera.SetActive(true);
        charCamera.SetActive(false);
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        iceWall.GetComponent<IceWall>().BreakIcewall();
        yield return new WaitForSeconds(2);
        introCamera.SetActive(false);
        charCamera.SetActive(true);
    }
}
