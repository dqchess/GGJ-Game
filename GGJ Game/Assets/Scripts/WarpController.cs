using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpController : MonoBehaviour
{
    public float startZ;
    public float startScale;
    public float endScale;
    public float cScale;
    public float time;
    public GameObject warpBubble;
    private float moveSpeed;
    private bool warp = false;
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = startZ / time;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void gotothewarp()
    {
        warp = true;
    }
    private void warpspeed()
    {
        if (warp)
        {
            warpBubble.SetActive(true);
            if (transform.position.z > 0)
            {

                transform.position -= Vector3.forward * Time.deltaTime * moveSpeed;
                cScale = (1 - transform.position.z / startZ) * endScale;
                transform.localScale = new Vector3(cScale, cScale, cScale);

            }
        }
    }
}
