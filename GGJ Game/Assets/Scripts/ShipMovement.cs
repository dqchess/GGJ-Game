using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Vector3 movePos;
    public Vector3 moveRot;

    private Vector3 moveDirection;
    private Rigidbody myRigidbody;
    private Transform myTransform;
    void Start()
    {

        myRigidbody = transform.GetComponent<Rigidbody>();
        myTransform = transform;
        movePos = new Vector3(0, 0, 0);
        moveRot = new Vector3(0, 0, 0);
    }

    public void callMove(Vector3 move, Vector3 rote)
    {
        movePos = move;
        moveRot = rote;
        ActuallyMove();
    }

    private void ActuallyMove()
    {
        moveDirection = transform.right * movePos.x + transform.up * movePos.y + transform.forward * movePos.z;
        myRigidbody.MovePosition(transform.position + moveDirection);
        myRigidbody.AddRelativeTorque(moveRot);

    }
}
