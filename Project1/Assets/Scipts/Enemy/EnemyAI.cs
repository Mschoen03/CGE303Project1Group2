using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;



public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to player's position
    public float speed = 2f; // Enemy movement speed
    public float attackRange = 1.5f; // Distance needed to attack
    public float attackCooldown = 2f; // Time between attacks
    public int punchDamage = 10;
    public int kickDamage = 15;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Vector3 originalScale;
    private float attackTimer; // Timer to track attacks

    void Start()
    {
        originalScale = transform.localScale; // Store original scale
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>(); // Get Animator (for attack animations)
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer > attackRange)
            {
                MoveTowardsPlayer();
            }
            else
            {
                AttackPlayer(); // Attack when close enough
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        // Flip sprite based on direction
        if (direction.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (direction.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    void AttackPlayer()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0f) // Only attack if cooldown is over
        {
            int attackType = UnityEngine.Random.Range(0, 2); // Explicitly use UnityEngine.Random

            if (attackType == 0)
            {
                Punch();
            }
            else
            {
                Kick();
            }

            attackTimer = attackCooldown; // Reset attack timer
        }
    }

    void Punch()
    {
        
        if (animator != null) animator.SetTrigger("Punch"); // Trigger punch animation
        DealDamage(punchDamage);
    }

    void Kick()
    {
       
        if (animator != null) animator.SetTrigger("Kick"); // Trigger kick animation
        DealDamage(kickDamage);
    }

    void DealDamage(int damage)
    {
        if (player != null)
        {
            HealthBar playerHealth = player.GetComponent<HealthBar>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}