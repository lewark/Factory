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

    public GameObject gearParent;
    public GameObject gearPrefab;

    public float accel = 2f;
    public float topSpeed = 10;

    bool rotating = false;
    float speed = 0;
    float gearInterval = 100f;
    float timeToGear = 7;
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

            contraptionCamera.transform.localPosition += new Vector3(0, 0, Time.deltaTime * 0.5f);

            timeToGear -= Time.deltaTime;
            if (timeToGear <= 0)
            {
                timeToGear = gearInterval / speed;
                GameObject gearObj = Instantiate(gearPrefab, gearParent.transform);
                Vector3 angle = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
                gearObj.transform.localPosition = angle * 10 + contraptionCamera.transform.localPosition - new Vector3(0,0,2); //new Vector3(0, Random.Range(-10f, 0f), 0);
                float scale = Random.Range(0.5f, 1.0f);
                gearObj.transform.localScale = new Vector3(scale, scale, scale);
                LargeGear largeGear = gearObj.GetComponent<LargeGear>();
                largeGear.speed = Random.Range(-10, 10);

            }
                
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
