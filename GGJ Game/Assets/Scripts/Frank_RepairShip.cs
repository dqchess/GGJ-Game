using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Frank_RepairShip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject repairPanel;
    public GameObject progressPanel;
    //public Image broken;
    public Image repairProgress;
    public ShipStatus shipStatus;

    public Frank_AddEnergy addEnergy;

    [SerializeField]
    int repairAmount;

    float repairTime;
    float maxRepairTime;

    public bool isUpgraded = false; // Is the time runned out

    public static int partsRepaired;

    private void Start()
    {
        repairProgress.fillAmount = 0;

        repairTime = repairAmount;

        maxRepairTime = repairTime;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        repairPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        repairPanel.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(shipStatus.crystal >= repairAmount && addEnergy.curEnergy > 0)
        {
            progressPanel.gameObject.SetActive(true);
            shipStatus.crystal -= repairAmount;
            isUpgraded = true;

            partsRepaired++;

            shipStatus.lightsystem_Set(true);

            addEnergy.energyFiller.fillAmount += .2f;
            addEnergy.curEnergy -= 1;
        }
    }

    private void Update()
    {
        if(isUpgraded)
        {
            repairTime -= Time.deltaTime;
            repairProgress.fillAmount = 1 - repairTime / maxRepairTime;
            repairPanel.SetActive(false);
        }

        if (repairTime <= 0)
        {
            //broken.gameObject.SetActive(false);
            progressPanel.gameObject.SetActive(false);

            gameObject.GetComponent<Image>().color = Color.white;

            shipStatus.sonar_Fixed();

            if (gameObject.tag == "Second")
            {
                shipStatus.maxCrystal = 20;
                shipStatus.maxEnergy = 20;
                shipStatus.maxMetal = 20;
            }

            if (gameObject.tag == "Fourth")
            {
                shipStatus.maxCrystal = 30;
                shipStatus.maxEnergy = 30;
                shipStatus.maxMetal = 30;
            }
        }
    }
}
