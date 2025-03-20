using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public GameObject player; // Drag your Stickman Player here
    public int maxHealth = 100; // Maximum health value
    private int currentHealth; // Player's current health

    public UnityEngine.UI.Image healthBarFill; // Explicitly specify UI Image
    public GameObject gameOverText; // UI Game Over Message

    private bool isGameOver = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();

        if (gameOverText != null)
        {
            gameOverText.SetActive(false); // Hide "Game Over" at start
        }
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return; // Stop taking damage after death

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)currentHealth / maxHealth; // Update health bar
        }
    }

    void GameOver()
    {
        isGameOver = true;
        if (gameOverText != null)
        {
            gameOverText.SetActive(true); // Show "You Lost"
        }
        Time.timeScale = 0f; // Pause the game
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f; // Resume game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart scene
        }
    }
}
