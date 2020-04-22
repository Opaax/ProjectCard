using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobile : MonoBehaviour
{
    protected ArenaPath _path = null;
    protected Action doAction = null;

    public ArenaPath Path { get => _path; set => _path = value; }

    private void Start()
    {
        SetModeVoid();
        InitPosition();
    }

    public void InitPosition ()
    {
        transform.position = _path.Settings.StartPoint + new Vector3(0, 0.5f, 0);
        transform.rotation = Quaternion.LookRotation(_path.Settings.EndPoint - _path.Settings.StartPoint);
        SetModeMove();
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
        if (transform.position.x > _path.Settings.EndPoint.x)
        {
            SetModeVoid();
            if (_path.Tween)
            {
                transform.transform.position = _path.Tween.Settings.StartPoint + new Vector3(0, 0.5f, 0);
                _path = _path.Tween;
            }
            else
                transform.transform.position = _path.Settings.StartPoint;
            SetModeMove();
        }
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
