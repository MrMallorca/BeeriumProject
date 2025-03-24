using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameLogic : MonoBehaviour
{
    HealthManage instance;
    //Aqui se intanciaran los personajes y se les asignaran las barras de vida.

    [SerializeField] List<GameObject> personajes;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;


    [Header("Input Actions")]
    public PlayerMovements.ActionSet actionSetPl1;
    public PlayerMovements.ActionSet actionSetPl2;


    private void Start()
    {
        {
            string personaje1 = CharacterSelectorManager.confirmedCharacter1;
            GameObject personaje = personajes.Find((x) => x.name == personaje1);
            InitCharacter1(personaje, player1.transform, actionSetPl1, "Player1");
        }

        {
            string personaje2 = CharacterSelectorManager.confirmedCharacter2;
            GameObject personaje = personajes.Find((x) => x.name == personaje2);
            InitCharacter2(personaje, player2.transform, actionSetPl2, "Player2");
        }
    }

    private void InitCharacter1(GameObject personaje, Transform playerTransform, PlayerMovements.ActionSet actionSet, string tag)
    {
        GameObject player = Instantiate(personaje, playerTransform.position, Quaternion.identity, playerTransform);
        player.tag = tag;

        BaseFighter baseFighter = player.GetComponent<BaseFighter>();
        baseFighter.InitInputs(actionSetPl1);

    }

    private void InitCharacter2(GameObject personaje, Transform playerTransform, PlayerMovements.ActionSet actionSet, string tag)
    {
        GameObject player = Instantiate(personaje, playerTransform.position, Quaternion.identity, playerTransform);
        player.tag = tag;

        BaseFighter baseFighter = player.GetComponent<BaseFighter>();
        baseFighter.InitInputs(actionSetPl2);

    }
}