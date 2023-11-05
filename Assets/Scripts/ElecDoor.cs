using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecDoor : MonoBehaviour
{
    private float openTime = 0.5f;
    private float closedPos = 0.46f;
    private float openPos = 1.3f;

    public GameObject leftDoor;
    public GameObject rightDoor;

    bool open = false;
    float progress = 1f;


    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (progress < 1)
        {
            float increment = Time.deltaTime / openTime;
            progress = Mathf.Min(progress + increment, 1.0f);

            float openProgress;
            if (open)
            {
                openProgress = progress;
            } else {
                openProgress = 1 - progress;
            }

            float doorPos = openProgress * openPos + (1 - openProgress) * closedPos;

            SetDoorPos(doorPos);
        }
    }

    public void ToggleOpen()
    {
        SetOpen(!open);
    }
    
    public void SetDoorPos(float doorPos)
    {
        SetX(leftDoor, -doorPos);
        SetX(rightDoor, doorPos);
    }
    private void SetX(GameObject obj, float x)
    {
        obj.transform.localPosition = new Vector3(x, obj.transform.localPosition.y, obj.transform.localPosition.z);
    }

    public void SetOpen(bool open)
    {
        if (this.open != open)
        {
            this.open = open;
            progress = 1 - progress;
            boxCollider.enabled = !open;
        }
    }
}
