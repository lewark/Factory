using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    CharacterController player;
    Rigidbody platformRigidBody;
    // Start is called before the first frame update
    virtual public void Start()
    {
        platformRigidBody = GetComponent<Rigidbody>();
        print(platformRigidBody);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("player collision enter");
            player = collision.gameObject.GetComponent<CharacterController>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("player collision exit");
            player = null;
        }

    }
    */

    public void MovePlatform(Vector3 offset)
    {
        //transform.localPosition += offset;
        platformRigidBody.MovePosition(platformRigidBody.position + offset);
        
        /*if (player != null)
        {
            print("moving player");
            player.Move(offset);
        }*/
    }

    public Rigidbody GetRigidbody()
    {
        return platformRigidBody;
    }
}
