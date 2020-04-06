using Com.PackSoor.ProjectCard.ProjectConfidential.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Characters : MonoBehaviour
{
    [SerializeField] private ScriptableCharacter _settings = null;

    #region Gameplay Stats
    private int _attack;
    private int _defense;
    private int _pv;

    public int Attack
    {
        get { return _attack; }
        set { _attack = value; }
    }

    public int Defense
    {
        get { return _defense; }
        set { _defense = value; }
    }

    public int Pv
    {
        get { return _pv; }
        set { _pv = value; }
    }
    #endregion
    #region Character Data Stats
    public ScriptableCharacter Settings => _settings;
    
    public int GetAttack ()
    {
        return _settings.Attack;
    }

    public int GetDefense()
    {
        return _settings.Defense;
    }

    public int GetPv()
    {
        return _settings.Pv;
    }
    #endregion
}
