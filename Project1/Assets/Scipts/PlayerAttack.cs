using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int punchDamage = 20; // Damage the player deals with a punch
    public int kickDamage = 30; // Damage the player deals with a kick
    private Collider2D enemyInRange; // Stores the enemy in range
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the player presses "H" to punch
        if (Input.GetKeyDown(KeyCode.H))
        {
            Punch();
        }

        // Check if the player presses "J" to kick
        if (Input.GetKeyDown(KeyCode.J))
        {
            Kick();
        }
    }

    private void Punch()
    {
        if (enemyInRange != null)
        {
            EnemyHealth enemyHealth = enemyInRange.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(punchDamage);
                Debug.Log("Enemy punched!");
            }
        }
        else
        {
            Debug.Log("No enemy in range to punch!");
        }
    }

    private void Kick()
    {
        if (enemyInRange != null)
        {
            EnemyHealth enemyHealth = enemyInRange.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(kickDamage);
                Debug.Log("Enemy kicked!");
            }
        }
        else
        {
            Debug.Log("No enemy in range to kick!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to an enemy
        if (other.CompareTag("Enemy"))
        {
            enemyInRange = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // If the enemy leaves the range, clear the reference
        if (other.CompareTag("Enemy") && enemyInRange == other)
        {
            enemyInRange = null;
        }
    }
}
