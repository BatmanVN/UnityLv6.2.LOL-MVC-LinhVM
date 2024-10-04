using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health health;
    [SerializeField] protected Slider healthValue;

    private void Start()
    {
        health.onHealthChanged.AddListener(UpdateHp);
    }
    protected void UpdateHp(float healthPoint, float maxHealthPoint)
    {
        healthValue.value = healthPoint / maxHealthPoint;
    }
}
