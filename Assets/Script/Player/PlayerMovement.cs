using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    [SerializeField] float speed;
    [SerializeField] float gravity = -9.81f * 2;
    [SerializeField] float jumpHeight;
    float realSpeed;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    bool dash = true;
    Vector3 velocity;
    [SerializeField] AudioClip dashing;
    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f);
    void Start()
    {
        Vector3 currentRotation = transform.eulerAngles;
        transform.eulerAngles = new Vector3(30f, 90f, 0f);
        controller = GetComponent<CharacterController>();
        realSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && dash)
        {
            StartCoroutine(Dash());

        }

    }
    IEnumerator Dash()
    {
        dash = false;
        speed = speed * 1.5f;
        SFXManager.Instance.PlaySoundFXClip(dashing, transform, 1f);
        yield return new WaitForSeconds(0.5f);
        speed = realSpeed;
        dash = true;
    }
}

