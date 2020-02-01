using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatus : MonoBehaviour
{
    public int crystal;
    public int energy;
    public int metal;


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Crystal")
        {
            crystal++;
        }

        if (other.collider.tag == "Energy")
        {
            energy++;
        }

        if (other.collider.tag == "Metal")
        {
            metal++;
        }
    }
}
