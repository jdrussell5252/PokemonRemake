using System.Data;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    public float followSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        if (offset == Vector3.zero)
        {
            offset = transform.position - playerTransform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 desiredPostition = playerTransform.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPostition, followSpeed * Time.deltaTime);

        }
    }
}