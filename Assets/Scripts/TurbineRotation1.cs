using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbineRotation1 : MonoBehaviour
{
    public float RotSpeed = 100;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, RotSpeed * Time.deltaTime*5, Space.Self);
    }
}
