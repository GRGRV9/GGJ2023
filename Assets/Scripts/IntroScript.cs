using System.Collections;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public GameObject introCamera;
    public GameObject charCamera;
    public GameObject iceWall;
    public GameObject Training1UI;
    public GameObject Training2UI;
    public GameObject Training3UI;
    public GameObject WinGameUI;
    public GameObject character;
    public GameObject mainMusic;

    private int training1Completed;
    private int training2Completed;
    private int training3Completed;

    public Bonfire trainingBonfire;
    public StoneWall trainingStoneWall;

    // Start is called before the first frame update
    void Start()
    {
        
        introCamera.SetActive(true);
        charCamera.SetActive(false);
        Training1UI.SetActive(false);
        Training2UI.SetActive(false);
        WinGameUI.SetActive(false);
        mainMusic.SetActive(true);

        training1Completed = PlayerPrefs.GetInt("Training1");
        training2Completed = PlayerPrefs.GetInt("Training2");
        training3Completed = PlayerPrefs.GetInt("Training3");

        StartCoroutine(Intro());
        if (training1Completed == 0)
        {
            StartCoroutine(Training1());
        }        
             
    }

    public void StopTraining1()
    {
        StopCoroutine(Training1());
        Training1UI.SetActive(false);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Training1", 1);
        if (training2Completed==0)
        {
            StartCoroutine(Training2());
        }             
    }

    public void StopTraining2()
    {
        StopCoroutine(Training2());
        Training2UI.SetActive(false);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Training2", 1);
        Debug.Log("Training2 Completed");
        if (training3Completed == 0)
        {
            StartCoroutine(Training3());
        }
    }

    public void StopTraining3()
    {
        StopCoroutine(Training3());
        Training3UI.SetActive(false);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Training3", 1);
        Debug.Log("Training3 Completed");
    }

    public void WinLevel()
    {
        Debug.Log("Win!");
        WinGameUI.SetActive(true);
        mainMusic.SetActive(false);
    }

    IEnumerator Intro()
    {
        Debug.Log("Intro");
        character.GetComponent<MovementController>().BlockInput();
        character.GetComponent<SpellController>().BlockInput();
        iceWall.GetComponent<IceWall>().BreakIcewall();
        yield return new WaitForSeconds(2);
        introCamera.SetActive(false);
        charCamera.SetActive(true);
        character.GetComponent<MovementController>().UnblockInput();
        character.GetComponent<SpellController>().UnblockInput();
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

    IEnumerator Training3()
    {
        Debug.Log("Training3");
        yield return new WaitForSeconds(4);
        Training3UI.SetActive(true);
        Time.timeScale = 0.2f;
        yield return new WaitForSeconds(4);
        Time.timeScale = 1;
        Training3UI.SetActive(false);
    }
}
