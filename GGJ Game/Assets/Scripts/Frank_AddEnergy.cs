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

    int maxEnergy = 5;
    public int curEnergy;

    private void Start()
    {
        curEnergy = maxEnergy;
    }

    public void ToggleEngine()
    {
        if(repairShip.isUpgraded == true)
        {
            engineOff.gameObject.SetActive(!engineOff.isActiveAndEnabled);
            engineOn.gameObject.SetActive(!engineOn.isActiveAndEnabled);

            shipStatus.lightingSwitch();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (engineOff.gameObject.activeInHierarchy == false)
            {
                engineOff.gameObject.SetActive(true);
                engineOn.gameObject.SetActive(false);
                sonarActivated = true;
            }
            else
            {
                engineOff.gameObject.SetActive(false);
                engineOn.gameObject.SetActive(true);
                sonarActivated = false;
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
        }
    }

    public void ToggleEnergyPanel()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);

        energyPanelButton.gameObject.SetActive(!energyPanelButton.gameObject.activeInHierarchy);
    }
}
