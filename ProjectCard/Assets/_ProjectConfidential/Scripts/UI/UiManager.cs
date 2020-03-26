using Com.PackSoor.ProjectCard.ProjectConfidential.UI.ScreenScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public bool initScreen = false;

    private AbstractScreen currentScreen = null;

    private void Awake()
    {
        TeamScreen.Back += AddScreen;
        TitleScreen.TitleToTeam += AddScreen;
    }


    private void Start()
    {
        if (initScreen)
            AddScreen(TitleScreen.Instance);

    }

    private void AddScreen(AbstractScreen screen)
    {
        if(currentScreen != null)
            currentScreen.Close();
        currentScreen = screen;
        currentScreen.Open();
    }

    private void OnDestroy()
    {
        TeamScreen.Back -= AddScreen;
        TitleScreen.TitleToTeam -= AddScreen;
    }
}
