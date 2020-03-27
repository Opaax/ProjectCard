using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Characters[] deck = null;

    private void Start()
    {
        //InitCard();
    }

    public void InitCard()
    {
        if (deck.Length < 1) return;

        Characters lead = deck[0];
        for (int i = deck.Length - 1; i >= 0; i--)
        {
            switch (lead.Settings.CardLead)
            {
                case CharacterLead.ATT:
                    deck[i].Settings.Attack += (int)DeckUtils.AddingStats(deck[i].Settings.Attack, lead.Settings.LeadAtt);
                    Debug.Log(deck[i].Settings.Attack);
                    break;
                case CharacterLead.DEF:
                    deck[i].Settings.Defense += (int)DeckUtils.AddingStats(deck[i].Settings.Defense, lead.Settings.LeadDef);
                    Debug.Log(deck[i].Settings.Defense);
                    break;
            }
        }        
    }

    public int GetTotalLife()
    {
        int lTotalLife = 0;

        for (int i = deck.Length - 1; i >= 0; i--)
        {
            Debug.Log(deck[i].gameObject.GetInstanceID());
            lTotalLife += deck[i].Settings.Pv;
        }

        return lTotalLife;
    }
}
