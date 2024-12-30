using UnityEditor.Build.Content;
using UnityEngine;

public class ashMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5f; // Movement speed
    public float rotationSpeed = 5f;

    private static ashMovement ashInstance;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        Vector3 move = Vector3.zero;
        float targetAngle = transform.eulerAngles.y;

        // Check inputs and set move direction and rotation
        if (Input.GetKey("w"))
        {
            move += Vector3.forward * moveSpeed;
            targetAngle = 0f; // Face forward
        }
        if (Input.GetKey("s"))
        {
            move += Vector3.back * moveSpeed;
            targetAngle = 180f; // Face backward
        }
        if (Input.GetKey("a"))
        {
            move += Vector3.left * moveSpeed;
            targetAngle = 270f; // Face left
        }
        if (Input.GetKey("d"))
        {
            move += Vector3.right * moveSpeed;
            targetAngle = 90f; // Face right
        }

        if (Input.GetKey("w") && Input.GetKey("a"))
        {
            move = new Vector3(-1, 0, 1).normalized * moveSpeed; //Diagonally Up-Left
            targetAngle = 315f;
        }
        if (Input.GetKey("w") && Input.GetKey("d"))
        {
            move = new Vector3(1, 0, 1).normalized * moveSpeed; //Diagonally Up-Right
            targetAngle = 45f;
        }
        if (Input.GetKey("s") && Input.GetKey("d"))
        {
            move = new Vector3(1, 0, -1).normalized * moveSpeed; //Diagonally Down-Right
            targetAngle = 135f;
        }
        if (Input.GetKey("s") && Input.GetKey("a"))
        {
            move = new Vector3(-1, 0, -1).normalized * moveSpeed; //Diagonally Down-Left
            targetAngle = 225f;
        }


        // Apply rotation
        transform.rotation = Quaternion.Euler(0, targetAngle, 0);

        // Move the character controller
        controller.Move(move * Time.deltaTime);
    }
}