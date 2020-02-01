using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    
    private ShipController shipController;
    [SerializeField]
    private Vector3 posInput;
    [SerializeField]
    private Vector3 rotInput;
    [SerializeField]
    private float Speed;

    private float Pitch;
    private float Yaw;
    private float UpDown;

    private bool Sonar;
    // Start is called before the first frame update
    void Start()
    {
        shipController = GetComponent<ShipController>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput();
        ResetInput();
    }
    //
    void FixUpdate()
    {
    }
    //Basic Movement Input
    private void movementInput()
    {
        Pitch = Input.GetAxisRaw("Pitch");
        Yaw = Input.GetAxisRaw("Yaw");
        UpDown = Input.GetAxisRaw("UpDown");
        Speed = Input.GetAxisRaw("SpeedControl");

        posInput = new Vector3(0, UpDown, Speed);
        rotInput = new Vector3(Pitch, Yaw, 0);

        shipController.getMovementInput(posInput, rotInput);
    }
    //Reset
    private void ResetInput()
    {
        if(Input.GetButtonDown("Reset"))
            shipController.getFunctionInput("Reset");
    }
    //Sona Input
    private void sonarInput()
    {        
    }


}
