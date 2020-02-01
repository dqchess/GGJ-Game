using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatus : MonoBehaviour
{
    public int crystal;
    public int energy;
    public int metal;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Crystal")
        {
            crystal++;
        }

        if (collider.tag == "Energy")
        {
            energy++;
        }

        if (collider.tag == "Metal")
        {
            metal++;
        }
    }
}
