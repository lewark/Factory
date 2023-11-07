using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSystem : MonoBehaviour
{
    public float speed = 0;
    public float sineAmplitude = 0;
    public float sineSpeed = 0;
    public float sinePhase = 0;
    public GameObject anchor = null;
    public GameObject[] forwardGears;
    public GameObject[] reverseGears;

    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float rotation = time * speed + Mathf.Sin(time * sineSpeed + sinePhase) * sineAmplitude;

        Quaternion angle = Quaternion.Euler(90, rotation, 0);
        transform.localRotation = angle;
        foreach (GameObject obj in forwardGears)
        {
            obj.transform.localRotation = angle;
        }

        angle = Quaternion.Euler(90, -rotation, 0);
        foreach (GameObject obj in reverseGears)
        {
            obj.transform.localRotation = angle;
        }
    }
}
