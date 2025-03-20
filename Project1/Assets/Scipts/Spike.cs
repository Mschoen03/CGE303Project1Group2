using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage = 10; // Damage dealt to the player

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player touches the spike
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
