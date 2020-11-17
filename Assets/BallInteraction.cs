using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour
{
    private Vector3 initLocation;
    // Start is called before the first frame update
    void Start()
    {
        initLocation = transform.position;
    }

    // Update is called once per frame
    //void update()
    //{
        
    //}

    public void StartInteraction()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
    public void ResetInteraction()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.position = initLocation;
    }
}
