using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scanner : MonoBehaviour
{
    public UnityEvent onSwitchTriggered;

    public GameObject cursor;

    bool playerNear = false;

    // Start is called before the first frame update
    void Start()
    {
        cursor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNear && Input.GetButtonDown("Fire1"))
        {
            onSwitchTriggered.Invoke();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerNear = true;
            cursor.SetActive(true);
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerNear = false;
            cursor.SetActive(false);
        }
    }
}
