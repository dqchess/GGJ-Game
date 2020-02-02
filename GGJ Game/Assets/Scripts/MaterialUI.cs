using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialUI : MonoBehaviour
{
    public Text amount;

    public ShipStatus shipStatus;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Crystal")
        {
            amount.text = shipStatus.crystal.ToString() + "/" + shipStatus.maxCrystal.ToString();
        }
        else if (gameObject.tag == "Energy")
        {
            amount.text = shipStatus.energy.ToString() + "/" + shipStatus.maxEnergy.ToString();
        }
        else if (gameObject.tag == "Metal")
        {
            amount.text = shipStatus.metal.ToString() + "/" + shipStatus.maxMetal.ToString();
        }
    }
}
