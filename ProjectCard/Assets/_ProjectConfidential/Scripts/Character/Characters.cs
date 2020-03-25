using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    [Header("Specs")]
    [SerializeField] private CharacterType _type;
    [SerializeField] private CharacterRarety _rarety;
    [SerializeField] private CharacterLead _lead;

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

    private void Start()
    {
        Debug.Log(_leadAtt);
    }
}