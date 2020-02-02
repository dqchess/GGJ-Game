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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        foreach (Transform FirePoint in firepoints)
        {
            FireSEF.Play();
            Instantiate(shell, FirePoint.position, FirePoint.rotation);
        }
    }
    private void fireControl()
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
