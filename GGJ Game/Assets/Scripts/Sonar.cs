using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    public float Range = 300f;
    public float time = 2.0f;
    private float Timer;
    private ShipController shipController;
    // Start is called before the first frame update
    void Start()
    {
        shipController = GetComponent<ShipController>();
        Timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0) {
            //Destroy(gameObject);
        }
        else
        {
            transform.localScale = new Vector3 ((1-Timer / time) * Range, (1 - Timer / time) * Range, (1 - Timer / time) * Range);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        GameObject otherObject = other.gameObject;
        if (other.tag == "Resources")
            shipController.ResourcesList_Add(otherObject);
        else if(other.tag == "Enemies")
            shipController.TargetList_Add(otherObject);
    }

}
