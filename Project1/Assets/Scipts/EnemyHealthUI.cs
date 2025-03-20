using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Make sure TextMeshPro is imported

public class EnemyHealthUI : MonoBehaviour
{
    public Transform enemy; // Assign your enemy GameObject in the Inspector
    public Vector3 offset; // Offset to adjust the text position
    private TMP_Text healthText;
    private Camera mainCamera;
    private EnemyHealth enemyHealth; // Reference to enemy's health script

    void Start()
    {
        healthText = GetComponent<TMP_Text>();
        mainCamera = Camera.main;
        enemyHealth = enemy.GetComponent<EnemyHealth>(); // Ensure your enemy has a health script
    }

    void Update()
    {
        if (enemy != null)
        {
            // Convert world position to screen space
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(enemy.position + offset);
            transform.position = screenPosition;

            // Update health display
            healthText.text = "HP: " + enemyHealth.currentHealth;
        }
    }
}
