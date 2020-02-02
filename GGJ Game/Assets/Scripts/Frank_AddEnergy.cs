using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frank_AddEnergy : MonoBehaviour
{
    public Image engineOff;
    public Image engineOn;
    public Image energyFiller;

    public ShipStatus shipStatus;

    public Button energyPanelButton;

    public Frank_RepairShip repairShip;

    public bool sonarActivated = false;

    public AudioSource add;
    public AudioSource noAdd;

    int maxEnergy = 5;
    public int curEnergy;

    private void Start()
    {
        curEnergy = 2;
        energyFiller.fillAmount = .6f;
    }

    //public void ToggleEngine()
    //{
    //    if(repairShip.isUpgraded == true)
    //    {
    //        engineOff.gameObject.SetActive(!engineOff.isActiveAndEnabled);
    //        engineOn.gameObject.SetActive(!engineOn.isActiveAndEnabled);

    //        shipStatus.lightingSwitch();
    //    }
    //}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (engineOff.gameObject.activeInHierarchy == false)
            {
                engineOff.gameObject.SetActive(true);
                engineOn.gameObject.SetActive(false);
                sonarActivated = false;
            }
            else
            {
                engineOff.gameObject.SetActive(false);
                engineOn.gameObject.SetActive(true);
                sonarActivated = true;
            }
        }
    }

    public void AddEnergy()
    {
        if(shipStatus.energy > 0 && curEnergy != maxEnergy)
        {
            energyFiller.fillAmount -= .2f;
            shipStatus.energy -= 1;
            curEnergy++;
            // play add sound
            add.Play();
        }
        else
        {
            //play no add sound
            noAdd.Play();
        }
    }

    public void ToggleEnergyPanel()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);

        energyPanelButton.gameObject.SetActive(!energyPanelButton.gameObject.activeInHierarchy);
    }
}
