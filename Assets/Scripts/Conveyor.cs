using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag == "Player")
        {
            Rigidbody playerRigidbody = obj.GetComponent<Rigidbody>();
            playerRigidbody.MovePosition(playerRigidbody.position + transform.right * Time.deltaTime * speed);
        }
    }
}
