using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMovingPlatform : MovingPlatform
{
    public float minPos = -3;
    public float maxPos = 3;
    public float speed = 2;

    private int direction = 1;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    void FixedUpdate()
    {
        float pos = GetRigidbody().transform.localPosition.x;
        
        if (direction > 0 && pos >= maxPos)
        {
            direction = -1;
        }
        if (direction < 0 && pos <= minPos)
        {
            direction = 1;
        }

        MovePlatform(new Vector3(direction * speed * Time.deltaTime, 0, 0));
    }
}
