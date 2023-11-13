using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MovingPlatform
{
    public ElecDoor elevatorDoor;
    public ElecDoor bottomDoor;
    public ElecDoor topDoor;

    bool topFloor = false;

    float elevatorSpeed = 2f;
    float topFloorPos = 0f;

    // Start is called before the first frame update
    public override void Start()
    {
        topFloorPos = topDoor.transform.localPosition.y;
        base.Start();
    }

    void FixedUpdate()
    {
        if (!IsAtDestination())
        {
            MoveTowardDestination();
        }
        else if (!elevatorDoor.IsOpen())
        {
            OpenDestinationDoor();
        }
    }

    void MoveTowardDestination()
    {
        float moveIncrement = elevatorSpeed * Time.deltaTime;
        if (!topFloor)
        {
            moveIncrement = -moveIncrement;
        }
        MovePlatform(new Vector3(0, moveIncrement, 0));
    }

    bool IsAtDestination()
    {
        float position = GetRigidbody().transform.localPosition.y;
        if (topFloor)
        {
            return position >= topFloorPos;
        }
        else
        {
            return position <= 0;
        }
    }

    void OpenDestinationDoor()
    {
        elevatorDoor.SetOpen(true);
        if (topFloor)
        {
            topDoor.SetOpen(true);
        }
        else
        {
            bottomDoor.SetOpen(true);
        }
    }

    void CloseDoors()
    {
        elevatorDoor.SetOpen(false);
        topDoor.SetOpen(false);
        bottomDoor.SetOpen(false);
    }

    public void ElevatorButtonPressed(bool isTopFloor)
    {
        MoveElevatorTo(isTopFloor);
    }

    void MoveElevatorTo(bool isTopFloor)
    {
        if (topFloor != isTopFloor)
        {
            CloseDoors();
            topFloor = isTopFloor;
        }

        if (IsAtDestination())
        {
            OpenDestinationDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && IsAtDestination())
        {
            MoveElevatorTo(!topFloor);
        }
    }
}
