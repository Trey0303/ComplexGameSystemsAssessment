using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public KinematicPlayerMotor motor;

    private NetworkVariable<Vector3> networkPosition;

    private float smoothTime = 0.05f;
    private Vector3 netVelocity;

    public override void OnNetworkSpawn()
    {
        motor.body.enabled = IsOwner;
    }

    private void Update()
    {
        //if player currently moving
        if (IsOwner)
        {
            // send inputs to motor
            motor.MoveInput(new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical")));

            if (Input.GetButtonDown("Jump"))
            {
                motor.JumpInput();
            }

            //update position
            OwnerSetPotionServerRpc(motor.Position);
        }

    }

    private void FixedUpdate()
    {
        //if player currently not moving
        if (!IsOwner)
        {
            motor.Position = Vector3.SmoothDamp(motor.Position, networkPosition.Value, ref netVelocity, smoothTime);
        }
    }


    //update network position with current position
    [ServerRpc(Delivery = RpcDelivery.Unreliable)]
    void OwnerSetPotionServerRpc(Vector3 newPos)
    {
        networkPosition.Value = newPos;
    }
}
