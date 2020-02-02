using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    public float Range = 300f;
    public float time = 2.0f;
    private float Timer;
    public ShipController shipController;
    // Start is called before the first frame update
    void Start()
    {
        Timer = time;
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0) {
            Timer = time;
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
        }
        else
        {
            transform.localScale = new Vector3 ((1-Timer / time) * Range, (1 - Timer / time) * Range, (1 - Timer / time) * Range);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;
        if (other.tag == "Crystal")
            shipController.ResourcesList_Add(otherObject);
        else if (other.tag == "Energy")
            shipController.ResourcesList_Add(otherObject);
        else if(other.tag == "Enemies")
            shipController.TargetList_Add(otherObject);
    }

}
