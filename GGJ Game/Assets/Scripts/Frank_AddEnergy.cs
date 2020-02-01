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

    int maxEnergy = 5;
    int curEnergy;

    public void ToggleEngine()
    {
        engineOff.gameObject.SetActive(!engineOff.isActiveAndEnabled);
        engineOn.gameObject.SetActive(!engineOn.isActiveAndEnabled);
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
}
