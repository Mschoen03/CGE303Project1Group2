using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 20; // Damage the player deals
    private Collider2D enemyInRange; // Stores the enemy in range

    void Update()
    {
        // Check if the player presses "H" to attack
        if (Input.GetKeyDown(KeyCode.H))
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (enemyInRange != null)
        {
            // Try to get the EnemyHealth component and deal damage
            EnemyHealth enemyHealth = enemyInRange.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
                Debug.Log("Enemy hit!");
            }
        }
        else
        {
            Debug.Log("No enemy in range to attack!");
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
