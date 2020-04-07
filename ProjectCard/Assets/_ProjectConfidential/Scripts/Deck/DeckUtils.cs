using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeckUtils
{
    static public float TransformToPercent (int value)
    {
        return (float)value/100;
    }

    static public float AddingStats(int stat, int leadStat)
    {
        return stat * TransformToPercent(leadStat);
    }
}
