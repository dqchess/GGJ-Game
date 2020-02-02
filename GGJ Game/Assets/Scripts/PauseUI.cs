using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public ShipStatus shipStatus;

    public GameObject youLose;
    public GameObject pause;

    public static bool isPaused = false;

    private void Start()
    {
        if (isPaused)
        {
            isPaused = false;
        }
       pause.SetActive(false);
    }
    private void Update()
    {
        if(shipStatus.health <= 0)
        {
            youLose.SetActive(true);
            pause.SetActive(false); // SAFETY
        }
        else
        {
            youLose.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (shipStatus.health > 0) // If player died then player can't press pause
            {
                if(isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }

        }
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
