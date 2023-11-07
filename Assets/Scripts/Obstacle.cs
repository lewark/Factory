using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public EndMenu endMenu;
    public string endMessage;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnGameEnd();
        }
    }

    protected void OnGameEnd()
    {
        endMenu.hasWon = false;
        endMenu.Enable();
        endMenu.SetEndMessage(endMessage);
    }
}
