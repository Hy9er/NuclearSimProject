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

    
    // Start is called before the first frame update

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
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            playerFan.SetActive(true);
        }
    }



}
