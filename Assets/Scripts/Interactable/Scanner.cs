using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : Interactable
{
    public GameObject display;
    private void OnEnable()
    {
        display.SetActive(true);
    }

    private void OnDisable()
    {
        display.SetActive(false);
    }
}
