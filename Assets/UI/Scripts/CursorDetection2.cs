﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class CursorDetection2 : MonoBehaviour {

    private GraphicRaycaster gr;
    private PointerEventData pointerEventData = new PointerEventData(null);

    public Transform currentCharacter;

    public Transform token;
    public bool hasToken;

	void Start () {

        gr = GetComponentInParent<GraphicRaycaster>();

        TheLastStarsCS.instance.ShowCharacterInSlot2(1, null);

    }

    void Update () {

        //CONFIRM
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            if (currentCharacter != null)
            {
                TokenFollow(false);
                TheLastStarsCS.instance.ConfirmCharacter2(1, TheLastStarsCS.instance.characters[currentCharacter.GetSiblingIndex()]);
            }
        }

        //CANCEL
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            TheLastStarsCS.instance.confirmedCharacter2 = null;
            TokenFollow(true);
        }

        if (hasToken)
        {
            Vector3 offset = new Vector3(-0.3f, 0f, 0f);
            token.position = transform.position + offset;
        }

        pointerEventData.position = Camera.main.WorldToScreenPoint(transform.position);
        List<RaycastResult> results = new List<RaycastResult>();
        gr.Raycast(pointerEventData, results);

        if (hasToken)
        {
            if (results.Count > 0)
            {
                Transform raycastCharacter = results[0].gameObject.transform;

                if (raycastCharacter != currentCharacter)
                {
                    if (currentCharacter != null)
                    {
                        currentCharacter.Find("selectedBorder").GetComponent<Image>().DOKill();
                        currentCharacter.Find("selectedBorder").GetComponent<Image>().color = Color.clear;
                    }
                    SetCurrentCharacter(raycastCharacter);
                }
            }
            else
            {
                if (currentCharacter != null)
                {
                    currentCharacter.Find("selectedBorder").GetComponent<Image>().DOKill();
                    currentCharacter.Find("selectedBorder").GetComponent<Image>().color = Color.clear;
                    SetCurrentCharacter(null);
                }
            }
        }
		
	}

    void SetCurrentCharacter(Transform t)
    {
        
        if(t != null)
        {
            t.Find("selectedBorder").GetComponent<Image>().color = Color.white;
        }

        currentCharacter = t;

        if (t != null)
        {
            int index = t.GetSiblingIndex();
            CharacterUI character = TheLastStarsCS.instance.characters[index];
            TheLastStarsCS.instance.ShowCharacterInSlot2(1, character);
        }
        else
        {
            TheLastStarsCS.instance.ShowCharacterInSlot2(1, null);
        }
    }

    void TokenFollow (bool trigger)
    {
        hasToken = trigger;
    }
}
