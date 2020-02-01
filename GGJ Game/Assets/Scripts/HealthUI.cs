using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public ShipStatus shipStatus;
    public Image healthFiller;

    public Text repairCooldown;
    public Text damageCooldown;

    public void Start()
    {
        healthFiller.fillAmount = 1;
    }

    public void Update()
    {
        healthFiller.fillAmount = shipStatus.health / shipStatus.maxHealth;
        repairCooldown.text = ((int)shipStatus.repairCooldown).ToString();
        if(shipStatus.repairCooldown <= 0)
        {
            repairCooldown.text = 0f.ToString();
        }
        damageCooldown.text = ((int)shipStatus.damageCooldown).ToString();
        if(shipStatus.damageCooldown <= 0)
        {
            damageCooldown.text = 0f.ToString();
        }
    }

}
