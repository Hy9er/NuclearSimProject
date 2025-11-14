using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    public bool dead;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        transform.rotation = Quaternion.Euler(0, 0, 0);
        dead = false;
    }

    void Update()
    {
        if (!dead)
        {

            float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        }
        else
        {
            Cursor.lockState= CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
