using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public GameObject introCamera;
    public GameObject charCamera;
    public GameObject iceWall;
    public GameObject Training1UI;
    public GameObject Training2UI;

    public bool fireballCasted;
    public bool training1Completed;

    public bool iceballCasted;
    public bool training2Completed;

    // Start is called before the first frame update
    void Start()
    {
        introCamera.SetActive(true);
        charCamera.SetActive(false);
        Training1UI.SetActive(false);
        Training2UI.SetActive(false);

        StartCoroutine(Intro());
        StartCoroutine(Training1());        
    }

    public void StopTraining1()
    {
        StopCoroutine(Training1());
        Training1UI.SetActive(false);
        Time.timeScale = 1;

        StartCoroutine(Training2());       
    }

    public void StopTraining2()
    {
        StopCoroutine(Training2());
        Training2UI.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Training2 Completed");
    }

    IEnumerator Intro()
    {
        Debug.Log("Intro");
        iceWall.GetComponent<IceWall>().BreakIcewall();
        yield return new WaitForSeconds(2);
        introCamera.SetActive(false);
        charCamera.SetActive(true);
    }

    IEnumerator Training1()
    {
        Debug.Log("Training1");
        yield return new WaitForSeconds(4);
        Training1UI.SetActive(true);
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(4);
        Time.timeScale = 1;
        Training1UI.SetActive(false);
    }

    IEnumerator Training2()
    {
        Debug.Log("Training2");
        yield return new WaitForSeconds(4);
        Training2UI.SetActive(true);
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(4);
        Time.timeScale = 1;
        Training2UI.SetActive(false);
    }
}
