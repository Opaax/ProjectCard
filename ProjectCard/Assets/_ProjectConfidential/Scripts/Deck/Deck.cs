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
                    deck[i].Attack += (int)DeckUtils.AddingStats(deck[i].Settings.Attack, lead.Settings.LeadAtt);
                    Debug.Log(deck[i].Settings.Attack);
                    break;
                case CharacterLead.DEF:
                    deck[i].Defense += (int)DeckUtils.AddingStats(deck[i].Settings.Defense, lead.Settings.LeadDef);
                    Debug.Log(deck[i].Settings.Defense);
                    break;
                case CharacterLead.PV:
                    deck[i].Pv += (int)DeckUtils.AddingStats(deck[i].Settings.Pv, lead.Settings.LeadPv);
                    Debug.Log(deck[i].Settings.Defense);
                    break;
                case CharacterLead.ATTDEF:
                    deck[i].Attack += (int)DeckUtils.AddingStats(deck[i].Settings.Attack, lead.Settings.LeadAtt);
                    Debug.Log(deck[i].Settings.Attack);
                    deck[i].Defense += (int)DeckUtils.AddingStats(deck[i].Settings.Defense, lead.Settings.LeadDef);
                    Debug.Log(deck[i].Settings.Defense);
                    break;
                case CharacterLead.PVATT:
                    deck[i].Attack += (int)DeckUtils.AddingStats(deck[i].Settings.Attack, lead.Settings.LeadAtt);
                    Debug.Log(deck[i].Settings.Attack);
                    deck[i].Pv += (int)DeckUtils.AddingStats(deck[i].Settings.Pv, lead.Settings.LeadPv);
                    Debug.Log(deck[i].Settings.Defense);
                    break;
                case CharacterLead.PVDEF:
                    deck[i].Pv += (int)DeckUtils.AddingStats(deck[i].Settings.Pv, lead.Settings.LeadPv);
                    Debug.Log(deck[i].Settings.Defense);
                    deck[i].Defense += (int)DeckUtils.AddingStats(deck[i].Settings.Defense, lead.Settings.LeadDef);
                    Debug.Log(deck[i].Settings.Defense);
                    break;
                case CharacterLead.ATTDEFPV:
                    deck[i].Pv += (int)DeckUtils.AddingStats(deck[i].Settings.Pv, lead.Settings.LeadPv);
                    Debug.Log(deck[i].Settings.Defense);
                    deck[i].Defense += (int)DeckUtils.AddingStats(deck[i].Settings.Defense, lead.Settings.LeadDef);
                    Debug.Log(deck[i].Settings.Defense);
                    deck[i].Attack += (int)DeckUtils.AddingStats(deck[i].Settings.Attack, lead.Settings.LeadAtt);
                    Debug.Log(deck[i].Settings.Attack); 
                    break;
            }
        }        
    }

    public int GetTotalLife()
    {
        int lTotalLife = 0;

        for (int i = deck.Length - 1; i >= 0; i--)
        {
            lTotalLife += deck[i].Settings.Pv;
        }

        return lTotalLife;
    }

    public int GetCharacterAttack(int index)
    {
        return deck[index].GetAttack();
    }

    public int GetCharacterDefense(int index)
    {
        return deck[index].GetDefense();
    }

    public int GetCharacterPv(int index)
    {
        return deck[index].GetPv();
    }
}
