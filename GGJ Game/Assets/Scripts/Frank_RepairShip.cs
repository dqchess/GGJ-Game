using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Frank_RepairShip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject repairAmount;
    public Image broken;

    public void OnPointerEnter(PointerEventData eventData)
    {
        repairAmount.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        repairAmount.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        broken.gameObject.SetActive(false);
    }
}
