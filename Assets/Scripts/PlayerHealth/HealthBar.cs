using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [HideInInspector] public Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    internal void NotifyLifeChanged(float currentHealth, float startingHealth)
    {
        slider.maxValue = startingHealth;
        slider.value = currentHealth;
    }
}
