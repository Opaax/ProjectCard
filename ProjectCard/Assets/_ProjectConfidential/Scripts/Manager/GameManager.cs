using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UiManager uiManager = null;

    private Player player = null;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        uiManager = GameObject.FindObjectOfType(typeof(UiManager)) as UiManager;
        uiManager.OnPlayClicked += UiManager_Play_Clicked;
        uiManager.Init();
    }

    private void UiManager_Play_Clicked()
    {
        player = new Player();
        Deck lDeck = GameObject.FindObjectOfType(typeof(Deck)) as Deck;
        player.CurrentDeck = lDeck;
        player.Init();
    }

    private void OnDestroy()
    {
        uiManager.OnPlayClicked -= UiManager_Play_Clicked;
    }
}
