using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maneuver : MonoBehaviour
{
    public float maneuverAngle;
    public float manruverRange;
    public float manruverAcc;
    public float angaleAcc;
    public float newlocalposz = 0;
    public float newlocalrotz = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void maneuverMovement(Vector3 posInput, Vector3 rotInput)
    {
        //Speed
        if (posInput.z > 0)
            if (transform.localPosition.z < manruverRange - manruverAcc)
                newlocalposz = transform.localPosition.z + manruverAcc;
            else
                newlocalposz = manruverRange;
        else if (posInput.z < 0)
            if (transform.localPosition.z > -manruverRange + manruverAcc)
                newlocalposz = transform.localPosition.z - manruverAcc;
            else
                newlocalposz = -manruverRange;
        else if (posInput.z == 0)
        {
            if (transform.localPosition.z > 0.5 * manruverAcc)
                newlocalposz = transform.localPosition.z - manruverAcc;
            else if (transform.localPosition.z < -0.5 * manruverAcc)
                newlocalposz = transform.localPosition.z + manruverAcc;
            else
                newlocalposz = 0;
        }
        //yaw
        if (rotInput.y < 0)
                newlocalrotz = maneuverAngle;
        else if (rotInput.y > 0)
                newlocalrotz = -maneuverAngle;
        else if (rotInput.y == 0)
                newlocalrotz=0;

        transform.localPosition = new Vector3(0, 0, newlocalposz);
        transform.localEulerAngles = new Vector3(0, 0, newlocalrotz);
    }


}
