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
            switch (lead.CardLead)
            {
                case CharacterLead.ATT:
                    deck[i].Attack += (int)DeckUtils.AddingStats(deck[i].Attack, lead.LeadAtt);
                    Debug.Log(deck[i].Attack);
                    break;
                case CharacterLead.DEF:
                    deck[i].Defense += (int)DeckUtils.AddingStats(deck[i].Defense, lead.LeadDef);
                    Debug.Log(deck[i].Defense);
                    break;
            }
        }        
    }

    public int GetTotalLife()
    {
        int lTotalLife = 0;

        for (int i = deck.Length - 1; i >= 0; i--)
        {
            lTotalLife += deck[i].Pv;
        }

        return lTotalLife;
    }
}
