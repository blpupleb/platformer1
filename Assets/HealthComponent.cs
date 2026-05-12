using JetBrains.Annotations;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthComponent : MonoBehaviour
{
    private float Health = 20;
    public int maxHealth = 20;
    private float currentHealth;
    private float HealingValue = 4;
    private bool invincibilty;

    public delegate void OnHealthChangedHandler(float newHealth, float annountChanged);
    public event OnHealthChangedHandler OnHealthChanged;

    public delegate void OnHealthInitializedHandler(float newHealth);
    public event OnHealthInitializedHandler OnHealthInitialized;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        currentHealth = maxHealth;
        OnHealthInitialized?.Invoke(currentHealth);
    }

    public void AddDamage(float HealingValue)
    {
        if (!invincibilty)
        {
            currentHealth -= HealingValue;
            OnHealthChanged?.Invoke(currentHealth, HealingValue);
            invincibilty = true;
            StartCoroutine(ResetInvincibilty(3));
        }
        if (currentHealth < 0)
        {
            SceneManager.LoadScene("ekran_œmierci");
        }
    }

    IEnumerator ResetInvincibilty(float resetTime)
    {
        yield return new WaitForSeconds(resetTime);
        invincibilty = false;
    }

    public void AddHealth(float HealingValue)
    {
        currentHealth += HealingValue;
        OnHealthChanged?.Invoke(currentHealth, HealingValue);
        Health += HealingValue;

        if (Health >= maxHealth)
        {
            Health = maxHealth;
        }
    }
}
