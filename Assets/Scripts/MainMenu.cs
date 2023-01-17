using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject gameobject;

    IEnumerator Fade()
    {
        gameobject.SetActive(false);
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {   
        StartCoroutine(Fade());
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
