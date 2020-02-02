using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Canvas controls;

    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Tutorial()
    {
        controls.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        controls.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Credits()
    {
        //open new panel
    }
}
