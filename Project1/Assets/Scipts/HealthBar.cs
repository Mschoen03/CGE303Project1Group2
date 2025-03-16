using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Required for restarting the scene

public class HealthBar : MonoBehaviour
{
    public Image healthBarFill;
    public GameObject gameOverText; // UI text to show "You lose! Press R to try again"

    private float maxHealth = 100f;
    private float currentHealth;
    private bool isGameOver = false; // Track if the game is over

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        gameOverText.SetActive(false); // Hide game over message at start
    }

    public void TakeDamage(float damage)
    {
        if (isGameOver) return; // Stop taking damage if game is already over

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
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true); // Show "You lose!" message
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads the current scene
    }
}