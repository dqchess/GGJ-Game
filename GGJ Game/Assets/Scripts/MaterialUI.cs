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
            amount.text = "x" + shipStatus.crystal.ToString();
        }
        else if (gameObject.tag == "Energy")
        {
            amount.text = "x" + shipStatus.energy.ToString();
        }
        else if (gameObject.tag == "Metal")
        {
            amount.text = "x" + shipStatus.metal.ToString();
        }
    }
}
