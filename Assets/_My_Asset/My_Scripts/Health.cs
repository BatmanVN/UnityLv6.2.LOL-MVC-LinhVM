using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float healthPoint;
    [SerializeField] protected UnityEvent onDie;
    [SerializeField] protected UnityEvent onTakeDame;
    public UnityEvent<float, float> onHealthChanged;
    public bool dead => healthPoint <= 0;
    public float HealthPoint
    {
        get => maxHealth;
        set
        {
            healthPoint = value;
            onHealthChanged?.Invoke(healthPoint,maxHealth);
        }
    }

    private void Start()
    {
        HealthPoint = maxHealth;
    }
    protected void TakeDame(float dame)
    {
        if (dead) return;
        HealthPoint -= dame;
        onTakeDame?.Invoke();
        if (dead)
            Die();
    }

    protected void Die()
    {
        onDie?.Invoke();
    }
}
