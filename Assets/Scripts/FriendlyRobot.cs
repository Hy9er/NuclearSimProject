using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FriendlyRobot : MonoBehaviour
{

    public float MovementSpeed;

    public GameObject pickup;
    public GameObject robotBoricAcid;

    //public Transform orientation;

    float horizontalInput;
    float verticalInput;

    public PlyaerMovement player;

    Vector3 moveDirection;

    Rigidbody rb;

    [SerializeField]private bool robotControl;

    [SerializeField]
    private ReactorMalfunction reactor;

    public bool hasAcid;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        robotControl = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(this.transform.position, pickup.transform.position);
        //Debug.Log(distance);
        if (distance <= 4f)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {

                pickup.SetActive(false);
                robotBoricAcid.SetActive(true);
                hasAcid = true;

            }

        }



    }

    void FixedUpdate()
    {


        if(player.operatingRobot == true)
        {

        

        float verticalInput = Input.GetAxisRaw("Vertical");   // W/S for forward/backward
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // A/D for rotation

        // Move the player forward or backward
        Vector3 moveDirection = transform.forward * verticalInput;

        if (verticalInput == 0)
        {
            // Slow down to stop when no input
            rb.AddForce(-10f * rb.velocity);
        }
        else
        {
            // Apply forward/backward movement force
            rb.AddForce(moveDirection.normalized * MovementSpeed * 10f, ForceMode.Force);
        }

        
        float rotationAmount = horizontalInput * 100 * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up * rotationAmount);

        
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > MovementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MovementSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

        }
    }
}
