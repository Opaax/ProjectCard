///-----------------------------------------------------------------
/// Author : Enguerran COBERT
/// Date : 14/01/2020 17:00
///-----------------------------------------------------------------
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractScreen : MonoBehaviour 
{      
    public virtual void SetText () { }
    public void IsAnimEnd() { }
    public void Open() { }
    public void Close() { }
}
