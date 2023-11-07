using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("entered");
        if (other.CompareTag("Player"))
        {
            print("player entered");
            RobotController player = other.GetComponent<RobotController>();
            player.SetCheckpoint(transform.position);
        }
    }
}
