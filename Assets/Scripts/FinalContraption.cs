using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalContraption : MonoBehaviour
{
    public GameObject player;
    public GameObject trigger;
    public GameObject fakePlayer;
    public GameObject gear1;
    public GameObject gear2;
    public Camera mainCamera;
    public Camera contraptionCamera;

    public EndMenu endMenu;

    public float accel = 2f;
    public float topSpeed = 10;

    bool rotating = false;
    float speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        fakePlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (rotating)
        {
            speed = speed + accel * Time.deltaTime;
            float angleIncrement = speed * Time.deltaTime;
            gear1.transform.Rotate(new Vector3(0, 0, angleIncrement));
            gear2.transform.Rotate(new Vector3(0, 0, -angleIncrement));

            if (speed >= topSpeed)
            {
                endMenu.hasWon = true;
                endMenu.Enable();
                rotating = false;
            }
        }
    }

    public void TriggerContraption()
    {
        player.SetActive(false);
        fakePlayer.SetActive(true);
        trigger.SetActive(false);
        mainCamera.enabled = false;
        contraptionCamera.enabled = true;
        rotating = true;
    }
}
