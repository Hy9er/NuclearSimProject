using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotBehavior : MonoBehaviour
{
   
    public NavMeshAgent Agent;
    public List<Transform> waypoint;
    public int currentWayPointIndex = 0;
    public GameObject playerFan;
    public GameObject robotFan;

    public GameObject turbines;

    public void Awake()
    {
        
    }
    void Start()
    {
    }

  
    void Update()
    {
        if (waypoint.Count == 0) return;

        float distanceToWayPoint = Vector3.Distance(waypoint[currentWayPointIndex].position, transform.position);

        if (distanceToWayPoint <= 3)
        {
            currentWayPointIndex = (currentWayPointIndex + 1) % waypoint.Count;
        }

        Agent.SetDestination(waypoint[currentWayPointIndex].position);
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !turbines.GetComponent<Repair>().isFanActive)
        {
            robotFan.SetActive(false);
            playerFan.SetActive(true);
        }
    }



}
