using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool isGameOver = false;  // Track game over state
    private bool isGameWon = false;   // Track win state

   
    public Image healthBarFill; // UI Health Bar (for Image-based bars)
    public GameObject gameOverText; // UI Game Over Message
    public GameObject winText; // UI Win Message

    public HealthBarSlider healthbarslider;

    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        healthbarslider.SetMaxHealth(maxHealth);
        UpdateHealthBar();
        gameOverText.SetActive(false);
        winText.SetActive(false); // Hide win text at start
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver || isGameWon) return; // Stop taking damage if game is over or won

        currentHealth -= damage;
        healthbarslider.SetHealth(currentHealth);
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
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart
        }
    }
}