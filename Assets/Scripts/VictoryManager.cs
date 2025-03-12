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
        if(HealthBar.instance.slider_Player1.value <= 0)
        {
            Debug.Log("player1 victory");
            Player1Victory.enabled = true;
        }if(HealthBar.instance.slider_Player2.value <= 0)
        {
            Debug.Log("player2 victory");
            Player2Victory.enabled = true;
        }
    }
}
