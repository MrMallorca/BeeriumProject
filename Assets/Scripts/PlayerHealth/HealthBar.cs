using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [HideInInspector] public Slider slider;

    private void Awake()
    {
        Debug.Log("Healthbar awake");
        slider = GetComponent<Slider>();

        DoAwake();


    }

    protected virtual void DoAwake()
    {
        Debug.Log("Acceso a DOAWAKE()");
    }

    internal void NotifyLifeChanged(float currentHealth, float startingHealth)
    {
        slider.maxValue = startingHealth;
        slider.value = currentHealth;
    }
}
