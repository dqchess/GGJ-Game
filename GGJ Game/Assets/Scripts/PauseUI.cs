using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public ShipStatus shipStatus;

    public GameObject youLose;

    private void Update()
    {
        if(shipStatus.health <= 0)
        {
            youLose.SetActive(true);
        }
        else
        {
            youLose.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
