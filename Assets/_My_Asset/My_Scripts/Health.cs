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
    public bool beAttack;
    //[SerializeField] protected UnityEvent onTakeDame;
    public UnityEvent<float, float> onHealthChanged;
    public bool dead => healthPoint <= 0;
    //public float HealthPoint
    //{
    //    get => maxHealth;
    //    set
    //    {
    //        healthPoint = value;
    //        onHealthChanged?.Invoke(healthPoint,maxHealth);
    //    }
    //}

    private void Start()
    {
        healthPoint = maxHealth;
    }
    public void TakeDame(GameObject target ,float dame)
    {
        if (dead) return;
        target.GetComponent<Health>().healthPoint -= dame;
        onHealthChanged?.Invoke(target.GetComponent<Health>().healthPoint, target.GetComponent<Health>().maxHealth);
        beAttack = true;
        if (target.GetComponent<Health>().dead)
            Die();
    }

    protected void Die()
    {
        onDie?.Invoke();
    }
}
