using TMPro;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] TMP_Text Player1Victory;
    [SerializeField] TMP_Text Player2Victory;

    //public HealthBar healthBarPL1;
    //public HealthBar healthBarPL2;

    private void Awake()
    {

    }
    void Update()
    {
        //if(healthBarPL2.slider.value <= 0)
        //{
        //    Debug.Log("player1 victory");
        //    Player1Victory.enabled = true;
        //}if(healthBarPL1.slider.value <= 0)
        //{
        //    Debug.Log("player2 victory");
        //    Player2Victory.enabled = true;
        //}
    }
}
