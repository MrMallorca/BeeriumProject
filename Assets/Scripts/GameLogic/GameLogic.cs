using UnityEngine;
using UnityEngine.InputSystem;

public class GameLogic : MonoBehaviour
{
    HealthManage instance;
    //Aqui se intanciaran los personajes y se les asignaran las barras de vida.

    [SerializeField] GameObject[] personajes;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;


    [Header("Input Actions")]
    public PlayerMovements.ActionSet actionSetPl1;
    public PlayerMovements.ActionSet actionSetPl2;


    private void Start()
    {
        string personaje1 = CharacterSelectorManager.confirmedCharacter1;


        foreach (GameObject personaje in personajes)
        {
            if (personaje.name == personaje1)
            {
                GameObject p1 = Instantiate(personaje, player1.transform.position , Quaternion.identity, player1.transform);
                p1.tag = "Player1";

                PlayerMovements movements = p1.GetComponent<PlayerMovements>();
                movements.actionSet = actionSetPl1;
                break;
            }
        }

        string personaje2 = CharacterSelectorManager.confirmedCharacter2;


        foreach (GameObject personaje in personajes)
        {
            if (personaje.name == personaje2)
            {
                GameObject p2 = Instantiate(personaje, player2.transform.position = new Vector3(4.94f, -3.55f, 0), Quaternion.identity, player2.transform);
                p2.tag = "Player2";

                PlayerMovements movements = p2.GetComponent<PlayerMovements>();
                movements.actionSet = actionSetPl2;
                break;
            }
        }

        //instance.StartComponents();
    }

}