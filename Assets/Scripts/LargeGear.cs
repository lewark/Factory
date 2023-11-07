using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeGear : MonoBehaviour
{
    public float speed = 0;

    float rotation = 0;

    // Update is called once per frame
    void Update()
    {
        rotation += speed * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(90, rotation, 0);
        transform.localPosition = new Vector3(transform.localPosition.x * 0.99f, transform.localPosition.y, transform.localPosition.z * 0.99f);
    }
}