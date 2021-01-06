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

    public void ChangeMass(float value)
    {
        GetComponent<Rigidbody>().mass = value;
        transform.localScale = new  Vector3(value, value, value);
    }

    public void ChangeHeight(float value)
    {
        transform.position= new Vector3(0, value, 0) + initLocation;
    }
}
