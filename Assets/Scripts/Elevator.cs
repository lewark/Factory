using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public ElecDoor elevatorDoor;
    public ElecDoor bottomDoor;
    public ElecDoor topDoor;

    bool topFloor = false;
    bool nextFloor = true;

    float elevatorSpeed = 1f;
    float topFloorPos = 0f;

    // Start is called before the first frame update
    void Start()
    {
        topFloorPos = topDoor.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAtDestination())
        {
            MoveTowardDestination();
            if (IsAtDestination())
            {
                OpenDestinationDoor();
            }
        }
    }

    void MoveTowardDestination()
    {
        float moveIncrement = elevatorSpeed * Time.deltaTime;
        if (!topFloor)
        {
            moveIncrement = -moveIncrement;
        }
        SetElevatorPos(transform.localPosition.y + moveIncrement);
    }

    bool IsAtDestination()
    {
        if (topFloor)
        {
            return transform.localPosition.y >= topFloorPos;
        }
        else
        {
            return transform.localPosition.y <= 0;
        }
    }

    void OpenDestinationDoor()
    {
        if (topFloor)
        {
            topDoor.SetOpen(true);
        }
        else
        {
            bottomDoor.SetOpen(true);
        }
        elevatorDoor.SetOpen(true);
    }

    void CloseDoors()
    {
        topDoor.SetOpen(false);
        bottomDoor.SetOpen(false);
        elevatorDoor.SetOpen(false);
    }

    public void ElevatorButtonPressed(bool isTopFloor)
    {
        MoveElevatorTo(isTopFloor);
        nextFloor = !isTopFloor;
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

    void SetElevatorPos(float pos)
    {
        transform.localPosition = new Vector3(transform.localPosition.x, pos, transform.localPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MoveElevatorTo(nextFloor);
        }
    }
}
