using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private ShipMovement shipMovement;
    //Ship Setting
        //Speed
        public float AccSpeed = .01f;
        public float Pitch_Speed = .1f;
        public float Yaw_Speed = .1f;
        public float UpDown_Speed = 0.2f;
        //Limitation
        public float Speed_Min = -.25f;
        public float Speed_Max = .5f;
        public float Pitch_Min = -45f;
        public float Pitch_Max = 45f;
    //Movement    
        private float CurrentSpeed = 0f;
        private float Speed = 0.0f;
        private float Pitch = 0.0f;
        private float Yaw = 0.0f;
        private float UpDown = 0.0f;
    [SerializeField]
    private Vector3 pos;
    [SerializeField]
    private Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        shipMovement = GetComponent<ShipMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getMovementInput(Vector3 posInput, Vector3 rotInput)
    {
        //Pitch
        Pitch = rotInput.x;
        Yaw = rotInput.y;
        UpDown = posInput.y * .1f;
        //Speed
        Speed += posInput.z;
        if (posInput.z > 0)
        {
            if (Speed > Speed_Max - AccSpeed)
                Speed = Speed_Max;
        }else
        {
            if (Speed < Speed_Min + AccSpeed)
                Speed = Speed_Min;
        }
        pos = new Vector3(0, UpDown, Speed);
        rot = new Vector3(Pitch, Yaw, 0);
        shipMovement.callMove(pos, rot);
    }
    public void getFunctionInput(string functionType)
    {
        if (functionType.Equals("Reset"))
        {
            Speed = 0;
        }
    }
}
