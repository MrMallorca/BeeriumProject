using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameLogic : MonoBehaviour
{
    //Aqui se intanciaran los personajes y se les asignaran las barras de vida.

    [SerializeField] List<GameObject> personajes;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    [SerializeField] HealthBar healthBarPL1;
    [SerializeField] HealthBar healthBarPL2;

    Player_Health player_Health;


    [Header("Input Actions")]
    public PlayerMovements.ActionSet actionSetPl1;
    public PlayerMovements.ActionSet actionSetPl2;

    //public GameObject HealthBar_GO;


    private void Start()
    {

        {

            string personaje1 = CharacterSelectorManager.confirmedCharacter1;
            GameObject personaje = personajes.Find((x) => x.name == personaje1);

            if (personaje1 == "Random")
            {
                int choice = Random.Range(0, personajes.Count);

                personaje = personajes[choice];
                InitCharacter(personaje, player1.transform, actionSetPl1, "Player1");

            }
            else
            {
                InitCharacter(personaje, player1.transform, actionSetPl1, "Player1");
            }

        }

        {
            string personaje2 = CharacterSelectorManager.confirmedCharacter2;
            GameObject personaje = personajes.Find((x) => x.name == personaje2);

            if (personaje2 == "Random")
            {
                int choice = Random.Range(0, personajes.Count);

                personaje = personajes[choice];
                InitCharacter(personaje, player2.transform, actionSetPl2, "Player2");

            }
            else
            {
                InitCharacter(personaje, player2.transform, actionSetPl2, "Player2");
            }
        }
    }

    private void InitCharacter(GameObject prefabPersonaje, Transform playerTransform, PlayerMovements.ActionSet actionSet, string tag)
    {
        GameObject player = Instantiate(prefabPersonaje, playerTransform.position, Quaternion.identity, playerTransform);
        player.tag = tag;

        BaseFighter baseFighter = player.GetComponent<BaseFighter>();
        baseFighter.InitInputs(actionSet);

        //Player_Health player_Health = player.GetComponent<Player_Health>();
        ////player_Health.SetHealthBar(healthBar);

        //HealthBar healthBarRef = player.GetComponent<HealthBar>();
        //healthBarRef = HealthBar_GO.gameObject.GetComponentInChildren<HealthBar>();
        
    }
}