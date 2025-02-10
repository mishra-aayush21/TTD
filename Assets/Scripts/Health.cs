// Health.cs
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public UnityEvent OnDeath;
    public UnityEvent<int> OnHealthChanged;

    void Start() => currentHealth = maxHealth;

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Die()
    {
        OnDeath?.Invoke();
        // Add death logic (e.g., destroy object, play animation)
        Destroy(gameObject);
    }
}