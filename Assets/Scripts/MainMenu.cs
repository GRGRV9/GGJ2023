using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject gameobject;
    int currentSceneIndex;

    private void Start()
    {
        Debug.Log(currentSceneIndex = SceneManager.GetActiveScene().buildIndex);
    }


    IEnumerator Fade(int scene)
    {
        gameobject.SetActive(false);
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }

    public void NewGame()
    {   
        StartCoroutine(Fade(1));
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(Fade(currentSceneIndex+1));
    }
}
