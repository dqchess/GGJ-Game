using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStatus : MonoBehaviour
{
    public int crystal;
    public int energy;
    public int metal;

    public GameObject repairUI;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Crystal")
        {
            crystal++;
            Destroy(collider.gameObject);
        }

        if (collider.tag == "Energy")
        {
            energy++;
            Destroy(collider.gameObject);
        }

        if (collider.tag == "Metal")
        {
            metal++;
            Destroy(collider.gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            repairUI.SetActive(!repairUI.activeInHierarchy);
        }
    }
}
