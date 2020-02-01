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


    //Lighting
    public float SeaLevel = 42f;
    public float Depth_Max = 0f;
    public float DetectDepthRange = 10f;
    public float DetectRange_Min = 50f;
    public float DetectRange_Max = 500f;
    public GameObject waterBox;

    [SerializeField]
    private bool light = false;
    [SerializeField]
    private float DetectRange = 50f;
    [SerializeField]
    private float DetectDepth;
    [SerializeField]
    private float CurrentDepth;


    //-----------------------------------------
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

        //get current depth
        CurrentDepth = transform.position.y;
        //lighting check
        lightingCheck();
    }

    //lighting
    private void lightingCheck()
    {
        //safety check
        if (waterBox == null)
            return;
        //get DetectRange
        if (light)
        {
            DetectRange = DetectRange_Max;
            DetectDepth = SeaLevel - Depth_Max + DetectDepthRange;
            Debug.Log(SeaLevel - Depth_Max);
        }
        else
        {
            DetectRange = 50f;

            DetectDepth = SeaLevel - CurrentDepth + DetectDepthRange;
        }

        waterBox.transform.localScale = new Vector3(DetectRange,DetectDepth, DetectRange);
    }
}
