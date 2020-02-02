using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plasma : MonoBehaviour
{
    public float speed = 1000.0F;

    public GameObject metal;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.tag == "Obstacle")
        {

            int gacha = Random.Range(0, 2);
            Debug.Log(gacha);
            switch (gacha)
            {
                case 0:
                    Instantiate(metal, other.transform.parent.transform.position, other.transform.parent.transform.rotation);
                    break;
            }
           Destroy(other.transform.parent.gameObject);


        }
    }
}
