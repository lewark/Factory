using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    public GameObject switchHandle;

    // Start is called before the first frame update
    public override void Start()
    {
        onSwitchTriggered.AddListener(FlipSwitch);
        base.Start();

        onSwitchTriggered.Invoke(); // skip maze section
    }

    void FlipSwitch()
    {
        switchHandle.transform.localRotation = Quaternion.Euler(-25, 0, 0);
    }
}
