using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool isGameOver = false;  // Track game over state

    public Slider healthBar;  // UI Health Bar (for Slider-based bars)
    public Image healthBarFill; // UI Health Bar (for Image-based bars)
    public GameObject gameOverText; // UI Game Over Message

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        gameOverText.SetActive(false); // Hide game over text
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return; // Stop taking damage if dead

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
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;
        }
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
        Time.timeScale = 0f; // Pause game
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f; // Resume game
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart
        }
    }
}