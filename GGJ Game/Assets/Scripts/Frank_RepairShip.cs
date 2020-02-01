using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frank_RepairShip : MonoBehaviour
{
    //bool isBroken = true;
    public GameObject repairAmount;
    //public Image broken;
    //public Image notBroken;

    private void OnMouseEnter()
    {
        repairAmount.SetActive(true);
        Debug.Log("On");
    }

    private void OnMouseExit()
    {
        repairAmount.SetActive(false);
    }
}
