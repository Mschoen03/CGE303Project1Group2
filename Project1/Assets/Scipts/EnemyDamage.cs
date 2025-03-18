using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10; // Damage dealt to the player
    public float damageCooldown = 1.0f; // Time before the enemy can damage the player again
    private float nextDamageTime = 0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        // Ensure the enemy only deals damage at set intervals
        if (Time.time >= nextDamageTime)
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damage);
                nextDamageTime = Time.time + damageCooldown; // Reset cooldown timer
            }
        }
    }
}
