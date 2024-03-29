using Com.PackSoor.ProjectCard.ProjectConfidential.UI.ScreenScripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("Debugs")]
    public bool initScreen = false;
    public AbstractScreen screenToInit = null;

    private AbstractScreen currentScreen = null;

    public Action OnPlayClicked;

    private void Awake()
    {
        TeamScreen.Back += AddScreen;
        TitleScreen.TitleToTeam += AddScreen;
        TitleScreen.TitlePlayClicked += TitleScreen_Play_Clicked;
    }

    private void TitleScreen_Play_Clicked()
    {
        OnPlayClicked?.Invoke();
    }

    public void Init()
    {
        if (initScreen)
        {
            if (screenToInit)
                AddScreen(screenToInit);
            else
                AddScreen(TitleScreen.Instance);
        }
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
        TitleScreen.TitlePlayClicked += TitleScreen_Play_Clicked;
    }
}
