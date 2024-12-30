using NUnit.Framework.Internal;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.XR;

public class flowerModelSwap : MonoBehaviour
{

    [SerializeField]
    private MeshFilter meshFilter; // Referance to the MeshFilter component that will display the meshes.

    [SerializeField]
    private Mesh[] meshes; // Array of meshes used for the flower animation.
    Mesh mesh; // Stores the current mesh used by the MeshFilter.

    [SerializeField]
    private float timer, timerMax; // Timer variables for controlling the animation speed.

    private int meshCount; // Tracks the current index in the 'meshes' array.
    private Vector3 lastPosition; // Stores the object's position in the previous frane.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshCount = 0;
        mesh = meshFilter.mesh;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the object has moved since the last frame.
        if (transform.position != lastPosition)
        {
            // If the timer exceeds the max value, update the mesh.
            if (timer > timerMax)
            {
                meshFilter.mesh = meshes[meshCount]; // Set the current mesh in the MeshFilter.
                meshCount++; // Move to the next mesh in the array.
                if (meshCount >= meshes.Length)
                {
                    meshCount = 0; // Reset the index to loop the animation.
                }
                timer = 0; // Reset timer after updating the mesh.
            }
            else
            {
                timer += Time.deltaTime; // Increment the timer by the time elapsed since the last frame.
            }
        }
        else // If the object hasn't moved:
        {
            meshFilter.mesh = meshes[0]; // Set the mesh to the default (first mesh in the array).
            meshCount = 0; // Reset the mesh index to the first frame.
        }
    }//End of 'update'.
}