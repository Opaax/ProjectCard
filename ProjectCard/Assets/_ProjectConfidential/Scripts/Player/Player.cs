using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _life = 0;
    private Deck _currentDect = null;

    public int Life
    {
        get { return _life; }
        set { _life = value; }
    }

    public Deck CurrentDeck
    {
        get { return _currentDect; }
        set { _currentDect = value; }
    }

    public void Init()
    {
        _currentDect.InitCard();
        _life = CurrentDeck.GetTotalLife();

        Debug.Log(_life);
    }
}
