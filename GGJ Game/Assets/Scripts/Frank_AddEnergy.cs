using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frank_AddEnergy : MonoBehaviour
{
    public Image engineOff;
    public Image engineOn;
    public Image energyFiller;

    public void ToggleEngine()
    {
        engineOff.gameObject.SetActive(!engineOff.isActiveAndEnabled);
        engineOn.gameObject.SetActive(!engineOn.isActiveAndEnabled);
    }

    public void AddEnergy()
    {
        energyFiller.fillAmount -= .2f;
    }
}
