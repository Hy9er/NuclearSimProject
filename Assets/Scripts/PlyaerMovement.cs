using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyaerMovement : MonoBehaviour
{
    public float MovementSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;


    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private GameObject BoricAcid;

    [SerializeField]
    private GameObject BoricAcid2;

    [SerializeField]
    private GameObject SparePipe;

    [SerializeField]
    private GameObject SparePipeInHand;

    private float pickupDistance = 5;
    private RaycastHit ray;

    public bool operatingRobot;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        operatingRobot = false;
    }

    void FixedUpdate()
    {
        if (operatingRobot == false)
        {
            verticalInput = Input.GetAxisRaw("Vertical");
            horizontalInput = Input.GetAxisRaw("Horizontal");

            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;



            //if player is still, slow down until stop. Else move forward
            if (moveDirection.magnitude == 0)
            {
                rb.AddForce(-10f * rb.velocity);
            }
            else
            {
                rb.AddForce(moveDirection.normalized * MovementSpeed * 10f, ForceMode.Force);
            }

            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVel.magnitude > MovementSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * MovementSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }




        }

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            operatingRobot = false;
        }


        if (ray.collider != null)
        {

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out ray, pickupDistance, layerMask))
            {
                Debug.Log(ray.transform);
                
                GameObject item = ray.collider.gameObject;

                if(item.CompareTag("Boric Acid"))
                {
                    item.SetActive(false);
                    BoricAcid.gameObject.SetActive(true);
                }

                if (item.CompareTag("Acid Holder") && BoricAcid.activeSelf)
                {
                    BoricAcid.gameObject.SetActive(false);
                    BoricAcid2.gameObject.SetActive(true);

                }

                if (item.CompareTag("Computer"))
                {
                    operatingRobot = true;
                }
                if(item.CompareTag("Spare Pipe"))
                {
                    item.SetActive(false);
                    SparePipeInHand.SetActive(true); 
                }
                if(item.CompareTag("Acid Holder") && SparePipeInHand.activeSelf)
                {
                    SparePipeInHand.SetActive(false);
                    SparePipe.SetActive(true);
                }

            }
        }

    }
}
