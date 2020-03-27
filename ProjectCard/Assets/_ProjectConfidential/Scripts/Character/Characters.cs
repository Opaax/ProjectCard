using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    #region Specs
    [Header("Specs")]
    [SerializeField] private CharacterType _type;
    [SerializeField] private CharacterRarety _rarety;
    [SerializeField] private CharacterLead _lead;
    #endregion
    #region Lead
    [SerializeReference,HideInInspector] private int _leadAtt = 0;
    [SerializeReference, HideInInspector] private int _leadDef = 0;
    [SerializeReference, HideInInspector] private int _leadPv = 0;

    public int LeadAtt
    {
        get { return _leadAtt; }
        set { _leadAtt = value; }
    }

    public int LeadDef
    {
        get { return _leadDef; }
        set { _leadDef = value; }
    }

    public int LeadPv
    {
        get { return _leadPv; }
        set { _leadPv = value; }
    }
    #endregion
    #region Stats
    [Header("Stats")]
    [SerializeField, HideInInspector] private int _attack = 0;
    [SerializeField, HideInInspector] private int _defense = 0;
    [SerializeField, HideInInspector] private int _pv = 0;

    public int Attack
    {
        get { return _attack; }
        set { _attack = value;}
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

    #region GetterSetters
    public CharacterType CardType
    {
        get { return _type; }
        set { _type = value; }
    }

    public CharacterRarety CardRarety
    {
        get { return _rarety; }
        set { _rarety = value; }
    }

    public CharacterLead CardLead
    {
        get { return _lead; }
        set { _lead = value; }
    }
    #endregion

    #region baseStats
    public Dictionary<string, uint> basedStats = new Dictionary<string, uint>();
    #endregion

    private void Start()
    {
    }
}
