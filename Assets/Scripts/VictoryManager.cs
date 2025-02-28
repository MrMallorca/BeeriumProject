using TMPro;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] TMP_Text Player1Victory;
    [SerializeField] TMP_Text Player2Victory;

    public HealthBar instance;

    private void Awake()
    {

    }
    void Update()
    {
        if(HealthBar.instance.slider.value <= 0)
        {
            Debug.Log("Entra");
            Player1Victory.enabled = true;
        }
    }
}
