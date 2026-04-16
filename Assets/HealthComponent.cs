using JetBrains.Annotations;
using System;
using System.Collections;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    private float Health = 20;
    public float maxHealth = 20;

    public int currentHealth { get; private set; }

    public delegate void OnHealthChangedHandler(float newHelath, float annountChanged);
    public event OnHealthChangedHandler OnHealthChanged;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddDamage(float damage)
    {
        Health -= damage;
        //Debug.Log(Health);

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void reciveDamage(float healingValue)
    {
        currentHealth -= (int)healingValue;
    }

    public void AddHealth(float healingValue)
    {
        currentHealth += (int)healingValue;
        OnHealthChanged?.Invoke(currentHealth, healingValue);
        Health += healingValue;

            if(Health >= maxHealth)
        {
            Health = maxHealth;
        }
       // Debug.Log(Health);

}
}
