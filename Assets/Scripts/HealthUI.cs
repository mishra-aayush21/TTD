using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Health playerHealth; // Reference to the player's Health script
    public Slider healthSlider; // Reference to the Slider UI

    void Start()
    {
        // Initialize the slider's max value
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.currentHealth;
        // Listen for health changes
        playerHealth.OnHealthChanged.AddListener(UpdateHealthUI);
    }

    void UpdateHealthUI(int currentHealth)
    {
        // Update the slider value
        healthSlider.value = currentHealth;
    }
}