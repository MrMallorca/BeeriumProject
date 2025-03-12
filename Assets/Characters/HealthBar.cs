using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;

    public Slider slider_Player1;

    public Slider slider_Player2;

    //public GameObject victoryText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //private void Update()
    //{
    //    if(slider_Player1.value <= 0)
    //    {
    //        victoryText.SetActive(true);
    //    }
    //}

    public void maxHealth(float health_Player1, float health_Player2)
    {
        slider_Player1.maxValue = health_Player1;
        slider_Player1.value = health_Player1;
        
        slider_Player2.maxValue = health_Player2;
        slider_Player2.value = health_Player2;
    }

    public void SetHealth(float health_Player1, float health_Player2)
    {
        slider_Player1.value = health_Player1; //Player1

        slider_Player2.value = health_Player2; //Player2
    }
    public float GetHealth()
    {
        return slider_Player1.value;
    }
}
