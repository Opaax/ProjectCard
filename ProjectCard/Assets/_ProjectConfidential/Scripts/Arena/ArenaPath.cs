using Com.PackSoor.ProjectCard.ProjectConfidential.Arena;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPath : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] protected ArenaPathSetting _settings = null;
    [Space]
    [Header("Position")]
    [SerializeField] Vector3[] _points = null;
    [Space]
    [Header("Tween")]
    [SerializeField,HideInInspector] ArenaPath _tween = null;

    public ArenaPathSetting Settings => _settings;
    public ArenaPath Tween { get => _tween; set => _tween = value; }

    public Vector3[] Points
    {
        get { return _points; }
        set { _points = value; }
    }

    private void Start()
    {
        SortingPosition();
    }

    private void SortingPosition()
    {
        Array.Sort(_points, delegate (Vector3 point1, Vector3 point2) { return point1.x.CompareTo(point2.x); });
        _settings.StartPoint = _points[0];
        _settings.EndPoint = _points[1];
    }
}
