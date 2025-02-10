using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Health playerHealth; // Reference to the player's Health script
    public Image healthBarFill; // Reference to the HealthBarFill Image

    private float maxWidth; // Store the maximum width of the health bar

    void Start()
    {
        // Get the initial width of the health bar fill
        maxWidth = healthBarFill.rectTransform.sizeDelta.x;
        // Listen for health changes
        playerHealth.OnHealthChanged.AddListener(UpdateHealthUI);
        // Initialize the health bar
        UpdateHealthUI(playerHealth.currentHealth);
    }

    void UpdateHealthUI(int currentHealth)
    {
        // Calculate the new width based on current health
        float newWidth = (float)currentHealth / playerHealth.maxHealth * maxWidth;
        // Update the health bar width
        healthBarFill.rectTransform.sizeDelta = new Vector2(newWidth, healthBarFill.rectTransform.sizeDelta.y);
    }
}