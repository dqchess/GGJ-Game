using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Frank_RepairShip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject repairPanel;
    public GameObject progressPanel;
    public Image broken;
    public Image repairProgress;
    public ShipStatus shipStatus;

    [SerializeField]
    int repairAmount;

    float repairTime;
    float maxRepairTime;

    bool isUpgraded = false; // Is the time runned out

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
        if(shipStatus.crystal >= repairAmount)
        {
            progressPanel.gameObject.SetActive(true);
            shipStatus.crystal -= repairAmount;
            isUpgraded = true;
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
            broken.gameObject.SetActive(false);
            progressPanel.gameObject.SetActive(false);
        }    
    }
}
