using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Reference to the bird's Rigidbody2D component for physics manipulation
    public Rigidbody2D myRigidbody;

    // Strength of the bird's upward flap when the space key is pressed
    public float flapStrenght;

    // Reference to the LogicScript for handling game logic (e.g., game over)
    public LogicScript logic;

    // Tracks whether the bird is alive and able to interact with the game
    public bool birdIsAlive = true;

    // Called before the first frame update
    void Start()
    {
        // Finds the game object with the "Logic" tag and gets its LogicScript component
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Called once per frame
    void Update()
    {
        // If the space key is pressed and the bird is alive, apply upward force to flap
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrenght;
        }

        // If the bird moves outside the vertical bounds of the camera, trigger game over
        if (transform.position.y > Camera.main.orthographicSize || transform.position.y < -Camera.main.orthographicSize)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    // Called when the bird collides with another collider (e.g., ground or obstacle)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
