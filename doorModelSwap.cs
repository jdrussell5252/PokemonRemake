using UnityEngine;

public class doorModelSwap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    private MeshFilter doorMeshFilter;

    [SerializeField]
    private Mesh closedDoorMesh;

    [SerializeField]
    private Mesh openDoorMesh;

    private bool isOpen = false;
    
    void Start()
    {
        doorMeshFilter.mesh = closedDoorMesh;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && !isOpen);
        {
            openDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player") && isOpen);
        {
            closeDoor();
        }
    }

    private void openDoor()
    {
        isOpen = true;
        doorMeshFilter.mesh = openDoorMesh;
    }

    private void closeDoor()
    {
        isOpen = false;
        doorMeshFilter.mesh = closedDoorMesh;
    }
}
