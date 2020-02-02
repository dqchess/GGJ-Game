using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public int state;
    public GameObject ship1;
    public GameObject ship2;
    public ShipStatus shipStatus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            state = 1;
        if (Input.GetKeyDown(KeyCode.C))
            if (state == 1)
                state = 2;
            else if (state == 2)
                state = 3;
            else
                state = 0;
        if (Input.GetKeyDown(KeyCode.Alpha1)|| Input.GetKeyDown(KeyCode.Keypad1))
            if (state == 3)
                state = 4;
            else if (state == 6)
                state = 7;
        if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
            if (state == 4)
                state = 5;
            else
                state = 0;
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
            if (state == 5)
                state = 6;
            else
                state = 0;

        if (state == 7)
            if (Input.GetKeyDown(KeyCode.P))
            {
                ship1.SetActive(false);
                ship2.SetActive(true);
                
            }else if (Input.GetKeyDown(KeyCode.O)){
            shipStatus.crystal = 99;
            shipStatus.energy = 99;
            shipStatus.metal = 99;
        }

    }
}
