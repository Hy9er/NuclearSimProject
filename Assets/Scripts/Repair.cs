using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    bool isFanActive;
    public GameObject playerFan;

    //public GameObject turbine1;
    //public GameObject turbine2;
    //public GameObject turbine3;

    public TurbineRotation turbineRotation;
    public TurbineRotation2 turbineRotation2;
    public TurbineRotation2 turbineRotation21;



    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && playerFan.activeInHierarchy)
        {

            playerFan.SetActive(false);
            turbineRotation.enabled = true;
            turbineRotation2.enabled = true;
            turbineRotation21.enabled = true;

        }
    }
}
