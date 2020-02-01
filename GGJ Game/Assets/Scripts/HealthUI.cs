using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public ShipStatus shipStatus;
    public Image healthFiller;

    public bool isPartyToggled = false;

    public void Start()
    {
        healthFiller.fillAmount = 1;
    }

    public void Update()
    {
        healthFiller.fillAmount = shipStatus.health / shipStatus.maxHealth;

        //if (isPartyToggled)
        //{
        //    shipStatus.health _
        //}
    }

    public void ToggleRepairParty()
    {
        isPartyToggled = !isPartyToggled;
    }
}
