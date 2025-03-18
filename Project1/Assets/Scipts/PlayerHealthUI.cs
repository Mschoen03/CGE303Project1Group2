using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    public Transform player; // Assign your player GameObject in the Inspector
    public Vector3 offset; // Offset to adjust the text position
    private TMP_Text healthText;
    private Camera mainCamera;
    private PlayerHealth playerHealth; // Reference to player's health script

    void Start()
    {
        healthText = GetComponent<TMP_Text>();
        mainCamera = Camera.main;
        playerHealth = player.GetComponent<PlayerHealth>(); // Ensure your player has a health script
    }

    void Update()
    {
        if (player != null)
        {
            // Convert world position to screen space
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(player.position + offset);
            transform.position = screenPosition;

            // Update health display
            healthText.text = "HP: " + playerHealth.currentHealth;
        }
    }
}
