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

    public Frank_AddEnergy addEnergyPanel;


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
    private bool sonarSystem = false;
    //-----------------------------------------



    //sonar
    public GameObject SWController;
    //.........


    // buff
    public float[] repairParty;
    public float[] damageControl;
    public float[] waterLeaked;

    public float waterLeakedDmg;
    public float repairPartyDmg;

    public float timer; // for it to run once in Update

    private float m_repairCooldown;
    public float maxRepairCooldown = 30f;
    private float m_damageCooldown;
    public float maxDamageCooldowm = 60f;

    //---------------------------
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

        if (collider.tag == "Metal" && metal < maxMetal)
        {
            metal++;
            Destroy(collider.gameObject);
        }

        if (collider.tag == "Terrain")
        {
            health -= damageReceived;
        }

        if (collider.tag == "Enemy")
        {
            for (int i = 0; i < waterLeaked.Length; i++)
            {
                if (waterLeaked[i] <= 0)
                    waterLeaked[i] = 30f;
            }
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

        //buff update
        buffTimerUpdate();
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            hpBuffEffect();
            timer = 1f;
        }

        repairCooldown -= Time.deltaTime;
        damageCooldown -= Time.deltaTime;
    }

    // buffs
    public void SetRepairParty() // set the timer buff from 0 to 15
    {
        if(repairCooldown <= 0)
        {
            for (int i = 0; i < repairParty.Length; i++)
            {
                if (repairParty[i] <= 0)
                {
                    repairParty[i] = 15f;
                }
            }
            repairCooldown = maxRepairCooldown;
        }

    }

    public void SetDamageControl() // set the waterLeaked buff timer to 0
    {
        if(damageCooldown <= 0)
        {
            for (int i = 0; i < damageControl.Length; i++)
            {
                if (damageControl[i] <= 0)
                {
                    for (int f = 0; f < waterLeaked.Length; f++)
                    {
                        waterLeaked[f] = 0f;
                    }
                }
            }
            damageCooldown = maxDamageCooldowm;
        }
    }
    private void hpBuffEffect() // this is where the health will get damage from enemy
    {
        float repairPartyNum = 0; // call a empty float for it to store arrays of repairs and leaked
        float waterLeakedNum = 0;

        for (int i = 0; i < repairParty.Length; i++) // this is where the buff run, it starts as 0, in order to increase, timer has to be > 0
        {
            if (repairParty[i] > 0)
            {
                repairPartyNum++;
            }
        }

        for (int i = 0; i < waterLeaked.Length; i++)
        {
            if (waterLeaked[i] > 0)
            {
                waterLeakedNum++;
            }
        }

        health = health - waterLeakedNum * waterLeakedDmg + repairPartyNum * repairPartyDmg;
    }
    private void buffTimerUpdate() // this is how long the buff could run in the game
    {
        for (int i = 0; i < damageControl.Length; i++)
        {
            if (damageControl[i] > 0)
            {
                for (int t = 0; t < waterLeaked.Length; t++)
                {
                    waterLeaked[t] = 0;
                }
            }
        }
        for (int i = 0; i < waterLeaked.Length; i++) // if this is bigger than 0, where we set it above to activate it
        {                                            // minus time delta until it reaches false
            if (waterLeaked[i] > 0)
            {
                waterLeaked[i] -= Time.deltaTime;
            }
        }

        for (int i = 0; i < repairParty.Length; i++)
        {
            if (repairParty[i] > 0)
            {
                repairParty[i] -= Time.deltaTime;
            }
        }

        for (int i = 0; i < damageControl.Length; i++)
        {
            if (damageControl[i] > 0)
            {
                damageControl[i] -= Time.deltaTime;
            }
        }
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

    public float repairCooldown
    {
        get { return m_repairCooldown; }
        set { m_repairCooldown = value; }
    }

    public float damageCooldown
    {
        get { return m_damageCooldown; }
        set { m_damageCooldown = value; }
    }
    //Snoar
    public void sonar_Active()
    {
        if (sonarSystem && addEnergyPanel.sonarActivated == true)
            SWController.SetActive(true);
    }
    public void sonar_Fixed()
    {
        sonarSystem = true;
    }
}
