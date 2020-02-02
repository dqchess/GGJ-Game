using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plasma : MonoBehaviour
{
    public float speed = 1000.0F;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.tag == "Obstacle")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
