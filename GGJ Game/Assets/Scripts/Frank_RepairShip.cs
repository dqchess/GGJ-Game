using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Frank_RepairShip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject repairPanel;
    public Image broken;
    public Image repairProgress;
    public ShipController shipController;

    [SerializeField]
    int repairAmount;

    float repairTime = 5.0f;

    bool isUpgraded = false; // Is the time runned out 

    private void Start()
    {
        repairProgress.fillAmount = 0;
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
        if(shipController.crystal >= repairAmount)
        {
            shipController.crystal -= repairAmount;
            isUpgraded = true;
        }
    }

    private void Update()
    {
        if(isUpgraded)
        {
            repairTime -= Time.deltaTime;
            repairProgress.fillAmount = 1 - repairTime / 5;
        }

        if (repairTime <= 0)
        {
            broken.gameObject.SetActive(false);
        }    
    }
}
