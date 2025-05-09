using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    // Reference to the pipe prefab to instantiate
    public GameObject pipe;

    // Time interval between pipe spawns
    public float spawnRate = 2;

    // Timer to track time since last spawn
    private float timer = 0;

    // Maximum vertical distance pipes can spawn from the center point
    public float heightOffset = 10;

    // Horizontal distance between successive pipes
    public float horizontalSpacing = 10f;

    // Tracks the X position of the last spawned pipe to space them correctly
    private float lastPipeX = 0f;

    // Called before the first frame update
    void Start()
    {
        // Set initial X position and spawn the first pipe
        lastPipeX = transform.position.x;
        spawnPipe();
    }

    // Called once per frame
    void Update()
    {
        // Increment timer and check if it's time to spawn a new pipe
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    // Handles pipe instantiation at a randomized vertical position and spaced X position
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        // Generate a random Y position within the defined height range
        float spawnHeight = Random.Range(lowestPoint, highestPoint);

        // Determine the new pipe's X position based on the last one
        float spawnX = lastPipeX + horizontalSpacing;

        // Instantiate the pipe at the new position with the same rotation as the spawner
        Instantiate(pipe, new Vector3(spawnX, spawnHeight, 0), transform.rotation);

        // Update the last X position for spacing the next pipe
        lastPipeX = spawnX;
    }
}
