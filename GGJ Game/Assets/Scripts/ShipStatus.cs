using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipStatus : MonoBehaviour
{
    [SerializeField] private float m_health;
    [SerializeField] private float m_maxHealth = 100f;
    [SerializeField] private float m_damageReceived = 10f;

    [SerializeField] private int m_crystal;
    [SerializeField] private int m_energy;
    [SerializeField] private int m_metal;

    [SerializeField] private int m_maxCrystal = 20;
    [SerializeField] private int m_maxEnergy = 20;
    [SerializeField] private int m_maxMetal = 20;

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

    //System Status
    private bool lightSystem = false;

    //-----------------------------------------

    public void Awake()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Crystal" && crystal < maxCrystal)
        {
            crystal++;
            Destroy(collider.gameObject);
        }

        if (collider.tag == "Energy" && energy < maxEnergy)
        {
            energy++;
            Destroy(collider.gameObject);
        }

        if (collider.tag == "Metal"  && metal < maxMetal)
        {
            metal++;
            Destroy(collider.gameObject);
        }

        if(collider.tag == "Terrain")
        {
            health -= damageReceived;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
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
            DetectRange = DetectRange_Min;

            DetectDepth = SeaLevel - CurrentDepth + DetectDepthRange;
        }

        waterBox.transform.localScale = new Vector3(DetectRange, DetectDepth, DetectRange);
    }
    public void lightingSwitch()
    {
        if (lightSystem)
        {
            light = !light;
        }
    }
    public bool lightsystem_Check()
    {
        return lightSystem;
    }
    public void lightsystem_Set(bool status)
    {
        lightSystem = status;
    }

    public float health
    {
        get { return m_health; }
        set { m_health = value; }
    }

    public float maxHealth
    {
        get { return m_maxHealth; }
        set { m_maxHealth = value; }
    }

    public float damageReceived
    {
        get { return m_damageReceived; }
        set { m_damageReceived = value; }
    }

    public int crystal
    {
        get { return m_crystal; }
        set { m_crystal = value; }
    }

    public int energy
    {
        get { return m_energy; }
        set { m_energy = value; }
    }
    public int metal
    {
        get { return m_metal; }
        set { m_metal = value; }
    }

    public int maxCrystal
    {
        get { return m_maxCrystal; }
        set { m_maxCrystal = value; }
    }

    public int maxEnergy
    {
        get { return m_maxEnergy; }
        set { m_maxEnergy = value; }
    }

    public int maxMetal
    {
        get { return m_maxMetal; }
        set { m_maxMetal = value; }
    }
}
