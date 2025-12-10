using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorMalfunction : MonoBehaviour
{
    [SerializeField]
    private bool malfunctionFixed;

    public GameObject robot;
    public GameObject acid;

    public GameObject Rods;
    public GameObject boricAcidOnShelf;


    void Start()
    {
        malfunctionFixed = true;
        startMalfunction();
    }

    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, robot.transform.position);

        if (distance <= 3f)
        {
            if (Input.GetKeyDown(KeyCode.Q) && robot.GetComponent<FriendlyRobot>().hasAcid && !malfunctionFixed)
            {
                fixMalfunction();
            }
        }
    }

    public void startMalfunction()
    {
        malfunctionFixed = false;
        boricAcidOnShelf.SetActive(true);
        StartCoroutine(raiseRods());
    }

    public void fixMalfunction()
    {
        acid.SetActive(false);
        malfunctionFixed = true;
        StartCoroutine(lowerRods());
        boricAcidOnShelf.SetActive(true);
        robot.GetComponent<FriendlyRobot>().hasAcid = false;
    }

    IEnumerator lowerRods()
    {
        while (Rods.transform.localPosition.y > 10f)
        {
            Rods.transform.position += Vector3.down * 1f * Time.deltaTime;
            Debug.Log(Rods.transform.position.y);
            yield return null;

        }
    }

    IEnumerator raiseRods()
    {
        while (Rods.transform.localPosition.y < 16.14f)
        {
            Rods.transform.position += Vector3.up * 1f * Time.deltaTime;
            Debug.Log(Rods.transform.position.y);
            yield return null;

        }
    }

}
