using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{
    //[SerializeField] sensivity sense;
    [SerializeField] float mouseSensivity;
    [SerializeField] float topLimit = -90f;
    [SerializeField] float bottomLimit = 90f;
    float yRotation;
    float xRotation;

    InputAction looktAction;
    Vector2 lookInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //mouseSensivity = sensivity.instance.sense;
        //mouseSensivity = sense.sense;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, topLimit, bottomLimit);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
