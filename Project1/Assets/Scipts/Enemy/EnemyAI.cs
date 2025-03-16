using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    private SpriteRenderer spriteRenderer;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale; // Store original scale
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Calculate direction
            Vector2 direction = (player.position - transform.position).normalized;

            // Move enemy
            transform.position += (Vector3)direction * speed * Time.deltaTime;

            // Flip sprite based on direction
            if (direction.x > 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
            else if (direction.x < 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }


}
