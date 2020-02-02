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
    public GameObject shipmesh;
    public PlayerInput playerInput;
    public GameObject Win;
    public GameObject theCamera;
    public float shake;
    public float moveSpeed;
    public bool warp = false;
    public bool switch1 = true;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = startZ / time;
    }

    // Update is called once per frame
    void Update()
    {
        warpspeed();
    }

    public void gotothewarp()
    {
        warp = true;

    }
    private void warpspeed()
    {
        if (warp)
        {
            playerInput.enabled = false;
            warpBubble.SetActive(true);
            if (transform.localPosition.z > 0)
            {
                if (switch1)
                {
                    transform.localPosition -= Vector3.forward * Time.deltaTime * moveSpeed;
                    cScale = ((startZ - transform.localPosition.z) / startZ) * endScale;
                    transform.localScale = new Vector3(cScale, cScale, cScale);
                    shake = .5f * ((startZ - transform.localPosition.z) / startZ);
                    theCamera.transform.localPosition = new Vector3(Random.Range(0f, shake * 2f) - shake, theCamera.transform.localPosition.y, theCamera.transform.localPosition.z);
                    theCamera.transform.localPosition = new Vector3(theCamera.transform.localPosition.x, Random.Range(0f, shake * 1f) - shake, theCamera.transform.localPosition.z);
                }

            }
            else
            {
                shipmesh.transform.localPosition+= Vector3.forward * Time.deltaTime * 500;
                warpBubble.transform.parent=shipmesh.transform;
                Win.SetActive(true);
            }
        }
    }

}
