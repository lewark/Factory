using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : GameEnder
{
    public EndMenu endMenu;

    protected override string endOnTouch {
        get { return "Player"; }
    }

    protected override void OnGameEnd()
    {
        endMenu.hasWon = false;
        endMenu.Enable();
    }
}
