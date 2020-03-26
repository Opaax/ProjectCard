///-----------------------------------------------------------------
/// Author : Enguerran COBERT
/// Date : 14/01/2020 17:00
///-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

public delegate void ScreenBackButtonEventHandler(AbstractScreen screenToAdd);
public delegate void ScreenAddScreenButtonEventHandler(AbstractScreen screenToAdd);
public abstract class AbstractScreen : MonoBehaviour 
{      
    public virtual void SetText () { }
    public virtual void IsAnimEnd() { }
    public virtual void Open() 
    { 
        if(transform.childCount > 0)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    public virtual void Close() 
    {
        if (transform.childCount > 0)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
