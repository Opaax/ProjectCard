using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile : MonoBehaviour
{
    protected ArenaPath path = null;
    protected Action doAction = null;

    private void Start()
    {
        SetModeVoid();
        DebugTest();
    }

    private void DebugTest()
    {
        RaycastHit hit; 
        if(Physics.Raycast(transform.position,-transform.up,out hit,Mathf.Infinity))
        {
            Debug.Log("[RaycastMobile]" + " " + hit.transform);
            if (hit.transform.GetComponent<ArenaPath>())
            {
                path = hit.transform.GetComponent<ArenaPath>();
                transform.position = path.Settings.StartPoint + new Vector3(0, 0.5f, 0);
                transform.rotation = Quaternion.LookRotation(path.Settings.EndPoint - path.Settings.StartPoint);
                SetModeMove();
            }
        }
    }

    private void Update()
    {
        doAction();
    }

    private void FixedUpdate()
    {
        CheckEndPath();
    }

    private void CheckEndPath()
    {
        if (transform.position.x > path.Settings.EndPoint.x)
            SetModeVoid();
    }

    #region StateMachine
    protected void SetModeVoid()
    {
        doAction = DoActionVoid;
    }

    protected void SetModeMove ()
    {
        doAction = DoActionMove;
    }

    protected void DoActionVoid()
    {
        
    }

    protected void DoActionMove()
    {
        transform.position += transform.forward * 10f * Time.deltaTime;
    }
    #endregion
}
