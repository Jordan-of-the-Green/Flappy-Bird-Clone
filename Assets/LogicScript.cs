using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    // Keeps track of the player's current score
    public int playerScore;

    // UI Text component that displays the score on screen
    public Text scoreText;

    // Reference to the Game Over screen UI element
    public GameObject gameOverScreen;

    // Adds the specified value to the player's score and updates the UI
    [ContextMenu("Increase Score")] // Allows manual score increase from the Unity editor
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    // Reloads the current scene, effectively restarting the game
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Activates the Game Over screen UI
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
