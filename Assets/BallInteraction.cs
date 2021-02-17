using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour
{
    [SerializeField]
    GameObject massValueField;
    [SerializeField]
    GameObject heightValueField;
    [SerializeField]
    GameObject potentialValueField;
    
    private const float g = 9.81f;
    private Vector3 initLocation;
    private float initMass;
    private bool simulating = false;


    // Start is called before the first frame update
    void Start()
    {
        initLocation = transform.position;
        initMass = GetComponent<Rigidbody>().mass;
        RefreshDisplay();

    }

    // Update is called once per frame
    void Update()
    {
        if(simulating)
            RefreshDisplay();
    }

    public void StartInteraction()
    {
        GetComponent<Rigidbody>().useGravity = true;
        simulating = true;
    }
    public void ResetInteraction()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.position = initLocation;
        simulating = false;

    }

    public void ChangeMass(float value)
    {
        GetComponent<Rigidbody>().mass = value + initMass;
        //transform.localScale = new  Vector3(value, value, value);

        massValueField.GetComponent<UnityEngine.UI.Text>().text = GetComponent<Rigidbody>().mass.ToString();
        RefreshDisplay();

    }

    public void ChangeHeight(float value)
    {

        transform.position= new Vector3(0, value, 0) + initLocation ;
        heightValueField.GetComponent<UnityEngine.UI.Text>().text = transform.position.y.ToString();

        RefreshDisplay();
    }

    private float PE() // potential energy
    {
        return GetComponent<Rigidbody>().mass * g * transform.position.y; 
    }


    private void RefreshDisplay()
    {

        massValueField.GetComponent<UnityEngine.UI.Text>().text = GetComponent<Rigidbody>().mass.ToString();
        heightValueField.GetComponent<UnityEngine.UI.Text>().text = transform.position.y.ToString();
        potentialValueField.GetComponent<UnityEngine.UI.Text>().text = PE().ToString();
    }

}
