using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject theCamera;
    public float closeRange;
    public float farRange;
    public float speed;
    public float cameraRange = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        moveCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            moveCamera();
        }
    }
    private void moveCamera()
    {
        cameraRange = cameraRange - Input.GetAxis("Mouse ScrollWheel") * speed;
        theCamera.transform.localPosition = new Vector3(0, 0, -cameraRange);
        if (cameraRange > farRange)
        {
            cameraRange = farRange;
        }
        else if (cameraRange < closeRange)
        {
            cameraRange = closeRange;
        }
    }
}
