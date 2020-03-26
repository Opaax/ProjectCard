using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public Characters[] deck = null;

    private void Start()
    {
        InitCard();
    }

    public void InitCard()
    {
        if (deck.Length < 1) return;

        Characters lead = deck[0];
        for (int i = deck.Length - 1; i >= 0; i--)
        {
            float addingStats = 0;

            if (lead.CardLead == CharacterLead.ATT)
            {
                addingStats = deck[i].Attack * DeckUtils.TransformToPercent(lead.LeadAtt);
                deck[i].Attack += (int)addingStats;
                Debug.Log(deck[i].Attack);
            }
            else if (lead.CardLead == CharacterLead.DEF)
            {
                addingStats = deck[i].Defense * DeckUtils.TransformToPercent(lead.LeadDef);
                deck[i].Defense += (int)addingStats;
                Debug.Log(deck[i].Defense);
            }
        }
    }
}
