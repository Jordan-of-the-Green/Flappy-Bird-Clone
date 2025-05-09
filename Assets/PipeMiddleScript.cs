using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    // Reference to the LogicScript to update the score
    public LogicScript logic;

    // Called before the first frame update
    void Start()
    {
        // Finds the object tagged "Logic" and gets its LogicScript component
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // (not used here)
    void Update()
    {

    }

    // Called when another collider enters this trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object that entered is on layer 3 (usually the player layer), increase score by 1
        if (collision.gameObject.layer == 3)
        {
            logic.addScore(1);
        }
    }
}
