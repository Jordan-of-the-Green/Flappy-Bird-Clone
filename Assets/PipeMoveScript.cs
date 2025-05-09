using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    // Speed at which the pipe moves to the left
    public float moveSpeed = 5;

    // X position beyond which the pipe will be destroyed (off-screen)
    public float deadZone = -5;

    // (not used here)
    void Start()
    {

    }

    // Called once per frame
    void Update()
    {
        // Move the pipe left across the screen based on moveSpeed and deltaTime
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        // If the pipe goes past the deadZone, remove it from the scene
        if (transform.position.x < deadZone)
        {
            // Log pipe deletion for debugging purposes
            Debug.Log("Pipe Deleted");

            // Destroy the pipe GameObject
            Destroy(gameObject);
        }
    }
}
