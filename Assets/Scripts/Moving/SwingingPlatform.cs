using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody platformRigidbody;
    float time = 0;

    public float speed = 1;
    public float amplitude = 1;
    public float phase = 0;
    void Start()
    {
        platformRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        float angle = Mathf.Sin(time * speed + phase) * amplitude;

        Quaternion rotation = Quaternion.Euler(angle-90, 90, 90);

        platformRigidbody.MoveRotation(rotation);
    }
}
