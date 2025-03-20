using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public UnityEngine.UI.Image healthBarFill;
    public GameObject gameOverText;
    public GameObject winText;

    public bool isEnemy = false; // Determines if this is an enemy
    //public int nextSceneIndex = 1;
    public int collisionDamage = 10; // Damage when colliding with Player/Enemy

    private bool isGameOver = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();

        if (!isEnemy && gameOverText != null)
        {
            gameOverText.SetActive(false);
        }

        if (winText != null)
        {
            winText.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isGameOver) return;

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
            healthBarFill.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    void GameOver()
    {
        isGameOver = true;

        if (isEnemy)
        {
            PlayerWins();
        }
        else
        {
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }
            Time.timeScale = 0f; // Pause game when player dies
        }
    }

    void PlayerWins()
    {
        if (winText != null)
        {
            winText.SetActive(true);
        }

        SceneManager.LoadSceneAsync(3);
    }
    // Wait 2 seconds before loading next level


    

    void Update()
    {
        if (!isEnemy && isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }

    //  **Collision Damage: Player & Enemy Lose Health When They Collide**
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((isEnemy && collision.gameObject.CompareTag("Player")) || (!isEnemy && collision.gameObject.CompareTag("Enemy")))
        {
            HealthBar targetHealth = collision.gameObject.GetComponent<HealthBar>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(collisionDamage); // Deal damage to the other object
                TakeDamage(collisionDamage); // Self-inflict damage
            }
        }
    }
}
