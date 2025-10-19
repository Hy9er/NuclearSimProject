using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorMalfunction : MonoBehaviour
{
    [SerializeField]
    private bool malfunctionFixed;

    public GameObject robot;
    public GameObject acid;

    // Start is called before the first frame update
    void Start()
    {
        malfunctionFixed = false;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, robot.transform.position);
        Debug.Log(distance);
        if (distance <= 3f)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {

                acid.SetActive(false);
                malfunctionFixed = true;

            }

        }
    }
}
