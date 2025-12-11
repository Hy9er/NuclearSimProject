using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public bool isFanActive;
    public GameObject playerFan;

    //public GameObject turbine1;
    //public GameObject turbine2;
    //public GameObject turbine3;

    public TurbineRotation turbineRotation;
    public TurbineRotation2 turbineRotation2;
    public TurbineRotation2 turbineRotation21;

    public GameObject robotFan;


    void Start()
    {
        MalfunctionFix();
    }

    void Update()
    {
      
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && playerFan.activeInHierarchy)
        {
            MalfunctionFix();
        }
    }

    public void malfunctionStart()
    {
        robotFan.SetActive(true);
        turbineRotation.enabled = false;
        turbineRotation2.enabled = false;
        turbineRotation21.enabled = false;
        isFanActive = false;
    }

    public void MalfunctionFix()
    {
        playerFan.SetActive(false);
        turbineRotation.enabled = true;
        turbineRotation2.enabled = true;
        turbineRotation21.enabled = true;
        isFanActive = true;
    }
}
