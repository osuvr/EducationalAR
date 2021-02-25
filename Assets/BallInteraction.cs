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
    [SerializeField]
    GameObject kineticValueField;
    [SerializeField]
    GameObject totalValueField;
    [SerializeField]
    GameObject timeValueField;
    private const float g = 9.8f;
    private Vector3 initLocation;
    private float initMass;
    private bool simulating = false;
    private float timeScale= .5f;


    // Start is called before the first frame update
    void Start()
    {
        initLocation = transform.position;
        initMass = GetComponent<Rigidbody>().mass;
        Time.timeScale = timeScale;
        RefreshDisplay();
     }

    // Update is called once per frame
    void Update()
    {
        if (simulating)
            RefreshDisplay();

        if (Input.GetKeyDown("space"))
        {
            timeScale = Time.timeScale;
            Time.timeScale = 0;
        }
        if (Input.GetKeyUp("space"))
            Time.timeScale = timeScale;

        if (Input.GetKeyUp(KeyCode.Plus) || Input.GetKeyUp(KeyCode.KeypadPlus))
        {
            Time.timeScale = Mathf.Min(2, Time.timeScale + .1f);
            RefreshDisplay();
        }

        if (Input.GetKeyUp(KeyCode.Minus) || Input.GetKeyUp(KeyCode.KeypadMinus))
        {
            Time.timeScale = Mathf.Max(.1f, Time.timeScale-.1f);
            RefreshDisplay();
       }
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
        RefreshDisplay();

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

    private float KE() // potential energy
    {
        float spd = GetComponent<Rigidbody>().velocity.magnitude;
        return 0.5f*spd*spd* GetComponent<Rigidbody>().mass;
    }

    private void RefreshDisplay()
    {
        float ke = KE();
        float pe = PE();

        timeValueField.GetComponent<UnityEngine.UI.Text>().text = Time.timeScale.ToString("F1");
        massValueField.GetComponent<UnityEngine.UI.Text>().text = GetComponent<Rigidbody>().mass.ToString();
        heightValueField.GetComponent<UnityEngine.UI.Text>().text = transform.position.y.ToString();
        potentialValueField.GetComponent<UnityEngine.UI.Text>().text = pe.ToString();
        kineticValueField.GetComponent<UnityEngine.UI.Text>().text = ke.ToString();
        totalValueField.GetComponent<UnityEngine.UI.Text>().text = (pe+ke).ToString();
    }

}
