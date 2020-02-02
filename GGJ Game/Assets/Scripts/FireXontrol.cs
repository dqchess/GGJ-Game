using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireXontrol : MonoBehaviour
{
    public Transform[] firepoints;
    public GameObject shell;
    public float reloadTime = 0.5f;
    public AudioSource FireSEF;
    private float PrevFireTime;
    public static bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireControl();
    }
    private bool reloadCheck()
    {
        if (PrevFireTime + reloadTime < Time.time)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void fire()
    {
            FireSEF.Play();
        Instantiate(shell, firepoints[0].position, firepoints[0].rotation);
        Instantiate(shell, firepoints[1].position, firepoints[1].rotation);
    }
    private void fireControl()
    {
        if (isActive == false)
        {
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Fire");
                if (reloadCheck())
                {
                    fire();
                    PrevFireTime = Time.time;
                }
            }
        }
    }
}
