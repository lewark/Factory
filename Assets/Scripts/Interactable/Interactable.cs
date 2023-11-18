using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent onSwitchTriggered;

    public GameObject cursor;

    private AudioSource audioSource;

    bool playerNear = false;

    // Start is called before the first frame update
    public virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cursor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNear && Input.GetButtonDown("Fire1"))
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
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
