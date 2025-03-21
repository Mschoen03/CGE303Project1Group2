using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy took damage! Current Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Enemy Defeated!");
            LoadNextLevel(); // Load the next scene
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(5); // Make sure "Level 2" is correctly named in Build Settings
    }
}
