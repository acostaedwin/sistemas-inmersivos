using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    Transform cam;
    CharacterController control;

    public float speedCam = 300;
    public float playerSpeed = 8;
    public float gravityForce = -1;
    public float JumpForce = 20;

    float gravityMove = 0f;
    float camRotation = 0f;

    private void Start()
    {
        cam = transform.GetChild(0).GetComponent<Transform>();

        control = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0, mouseX, 0) * speedCam * Time.deltaTime);

        camRotation -= mouseY * speedCam * Time.deltaTime;
        camRotation = Mathf.Clamp(camRotation, -90, 90);
        cam.localRotation = Quaternion.Euler(new Vector3(camRotation, 0, 0));

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = (transform.right * moveX + transform.forward * moveZ) * playerSpeed * Time.deltaTime;

        control.Move(movement);

        control.Move(new Vector3(0, gravityMove, 0)* Time.deltaTime);

        if (!control.isGrounded)
        {
            gravityMove += gravityForce;//suma gradualmente la fuerza
        }
        else
        {
            gravityMove = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && control.isGrounded)
        {
            gravityMove = JumpForce;
        }
    }
}
