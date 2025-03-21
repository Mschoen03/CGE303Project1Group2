using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool isGameOver = false;
    private bool isGameWon = false;

    public Image healthBarFill;
    public GameObject gameOverText;
    public GameObject winText;

    public HealthBarSlider healthbarslider;

    public float blockDamageReduction = 0.5f; // 50% damage reduction when blocking

    void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
        healthbarslider.SetMaxHealth(maxHealth);
        UpdateHealthBar();
        gameOverText.SetActive(false);
        winText.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver || isGameWon) return;

        Animator animator = GetComponent<Animator>();
        if (animator != null && animator.GetBool("Block"))
        {
            damage = Mathf.RoundToInt(damage * blockDamageReduction);
            Debug.Log("Blocked damage reduced to: " + damage);
        }

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
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}